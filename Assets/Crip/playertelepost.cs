using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class playerteleposthome : MonoBehaviour
=======
public class playertelepost : MonoBehaviour
>>>>>>> main
{
    private GameObject currentTeleporter;

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            if (currentTeleporter != null )
            {
                transform.position = currentTeleporter.GetComponent<telepo>().GetDestination().position;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Telepost"))
        {
            currentTeleporter= collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Telepost"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter= null;
            }
        }
    }
}
