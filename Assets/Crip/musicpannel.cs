using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicpanel : MonoBehaviour
{
    [SerializeField] private GameObject paulmusic;
    public void pausemusic()
    {
        paulmusic.SetActive(true);
        Time.timeScale = 0;
    }
}