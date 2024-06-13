using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosss : MonoBehaviour
{
    [SerializeField] float start, end, speed, attackRange;
   
    Rigidbody2D rig;
    int isRight = 1;
    GameObject player;
    Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < attackRange)
        {
            Attack();
        }
        else
        {
            Run();
        }
        Flip();
    }

    void Run()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isRunning", true);

        var x_enemy = transform.position.x;
        if (x_enemy < start)
            isRight = 1;
        if (x_enemy > end)
            isRight = -1;

        transform.Translate(new Vector3(isRight * speed * Time.deltaTime, 0, 0));

        var y_enemy = transform.position.y;
        var x_player = player.transform.position.x;
        var y_player = player.transform.position.y;
        if ((x_player > start && x_player < end) && (y_player < y_enemy + 1 && y_player > y_enemy - 1))
        {
            if (x_player < x_enemy)
            {
                isRight = -1;
            }
            if (x_player > x_enemy)
            {
                isRight = 1;
            }
        }
    }

    void Attack()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isAttacking", true);

        // Di chuyển enemy về phía player khi tấn công
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // Logic để gây sát thương cho player có thể được thêm vào đây
    }

    void Flip()
    {
        transform.localScale = new Vector2(isRight, 1f);
    }

   
}
