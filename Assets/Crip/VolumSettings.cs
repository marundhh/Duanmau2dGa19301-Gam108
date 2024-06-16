using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VolumSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Volum"))
        {
            LoadVolume();
        }
        else
        {

            SetMusicVolume();   
        }
    }
    public void SetMusicVolume()
    {
        float volum = musicSlider.value;
        myMixer.SetFloat("music",Mathf.Log10(volum)*20);
        PlayerPrefs.SetFloat("Volum",volum);
    }
   private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Volum");
        SetMusicVolume();
    }

   
}
