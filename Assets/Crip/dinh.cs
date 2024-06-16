using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinh : MonoBehaviour
{
    [SerializeField] private float damage;


    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<heath>().TakeDamage(damage);

        }
    }
}
