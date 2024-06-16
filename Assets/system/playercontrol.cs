using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontrol3 : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rig;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpspeed = 5f;
    [SerializeField] float climbspeed = 10f;
    [SerializeField] private float damage;
    BoxCollider2D col;
    float startgravityscale;
    public BoxCollider2D feet;
    Animator ani;
    private cois m;
    public GameObject lost;
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
        startgravityscale = rig.gravityScale;
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<cois>();

    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
        ClimbLander();
    }
    void Run()
    {
        rig.velocity = new Vector2(moveInput.x * speed, rig.velocity.y);
        bool havemove = Mathf.Abs(rig.velocity.x) > Mathf.Epsilon;
        ani.SetBool("isRungning", havemove);
        if (col.IsTouchingLayers(LayerMask.GetMask("Ground")))
            ani.SetBool("isJumping", false);
        else
            ani.SetBool("isJumping", true);




    }
    void Flip()
    {
        bool havemove = Mathf.Abs(rig.velocity.x) > Mathf.Epsilon;
        if (havemove)
        {
            transform.localScale = new Vector2(Mathf.Sign(rig.velocity.x), 1f);
        }
    }
    void OnJump(InputValue value)
    {
        if (!col.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;
        if (value.isPressed)
        {
            rig.velocity += new Vector2(0f, jumpspeed);
        }
    }
    void ClimbLander()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rig.gravityScale = startgravityscale;
            if (col.IsTouchingLayers(LayerMask.GetMask("Climbing")))
                ani.SetBool("isClimbing",false);
            return;
        }
        rig.velocity = new Vector2(rig.velocity.x, moveInput.y * climbspeed);
        rig.gravityScale = 0;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            m.Addmoney();
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");

        }



    }


}
