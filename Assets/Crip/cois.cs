using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class cois : MonoBehaviour
{
    public int gold;
    public Text money;

    void Start()
    {
        gold = PlayerPrefs.GetInt("Money", 0);
    }

    // Update is called once per frame
    void Update()
    {
        money.text = PlayerPrefs.GetInt("Money", 0).ToString();
        //money.tag = gold.ToString();
    }
    public void Addmoney()
    {
        gold++;
        PlayerPrefs.SetInt("Money", gold);
    }
    public GameObject cointeffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject hieuung = Instantiate(cointeffect, transform.position, transform.localRotation);
            Destroy(hieuung, 3);
        }
    }
}
