using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadmap3 : MonoBehaviour
{
    public float delaySecond = 1;
    public string nameScene = "Boss";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            ModeSelect();
        }
    }
    public void ModeSelect()
    {
        StartCoroutine(LoadAfterDelay());
    }
    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);
        SceneManager.LoadScene(nameScene); ;
    }
}
