using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkdan : MonoBehaviour
{
    [SerializeField] GameObject GameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "checkarrows")
        {
            GameObject.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
