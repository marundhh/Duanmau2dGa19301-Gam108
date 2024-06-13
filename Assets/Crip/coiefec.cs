using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coiefec : MonoBehaviour
{
    public GameObject cointeffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false); Destroy(gameObject);
            GameObject hieuung = Instantiate(cointeffect, transform.position, transform.localRotation); 
            Destroy(hieuung, 3);
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
