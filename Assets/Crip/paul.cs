using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paul : MonoBehaviour
{
    [SerializeField] private GameObject paulpennel;
    public void pause()
    {
        paulpennel.SetActive(true);
        Time.timeScale = 0;
    }



    public void home()
    {
        SceneManager.LoadScene("home");
        Time.timeScale = 1;
    }

    public void dung()
    {
        paulpennel.SetActive(false);
        Time.timeScale = 1;
    }
    public void tiepTuc()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
