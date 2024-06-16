using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cua : MonoBehaviour
{
    [SerializeField] float start, end, speed,mid1,mid2;
    Rigidbody2D rig;
    int isRight = 1;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Run();
        Flip();
    }
    void Run()
    {
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
            if (x_player < y_enemy)
            {
                isRight = -1;
            }
            if (x_player > x_enemy)
            {
                isRight = 1;
            }
        }
        var z_enemy = transform.position.x;
        if (z_enemy < mid1)
            isRight = 1;
        if (z_enemy > mid2)
            isRight = -1;
        transform.Translate(new Vector3(isRight * speed * Time.deltaTime, 0, 0));
        var h_enemy = transform.position.y;
        var z_player = player.transform.position.x;
        var h_player = player.transform.position.y;
        if ((z_player > start && z_player < end) && (h_player < h_enemy + 1 && h_player > h_enemy - 1))
        {
            if (z_player < h_enemy)
            {
                isRight = -1;
            }
            if (z_player > z_enemy)
            {
                isRight = 1;
            }
        }

    }
    void Flip()
    {
        transform.localScale = new Vector2(isRight, 1f);
    }
}
