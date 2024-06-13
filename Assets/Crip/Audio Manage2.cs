using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage2 : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip background;
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    
}
