using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using UnityEngine.UI;

public class StarPlatinum : MonoBehaviour
{
    private Sprite play;
    private Sprite stop;
    private Image currentImage;
    private AudioClip timeStop;
    private AudioClip timeResume;
    private AudioSource audioSource;

    void Start()
    {
        play = Resources.Load<Sprite>("Sprites/play");
        stop = Resources.Load<Sprite>("Sprites/stop");
        timeStop = Resources.Load<AudioClip>("Sounds/ZaWarudo");
        timeResume = Resources.Load<AudioClip>("Sounds/ZaWarudoTimeResume");
        
        currentImage = GetComponent<Image>();
        
        //get audio source
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        if (Time.timeScale == 1)
        {
            audioSource.clip = timeStop;
            Time.timeScale = 0;
            currentImage.sprite = play;
            
            audioSource.Play();
        }
        else
        {
            audioSource.clip = timeResume;
            Time.timeScale = 1;
            currentImage.sprite = stop;
            audioSource.Play();
        }
    }
}
