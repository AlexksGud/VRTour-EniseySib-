using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Элемент хранящий панораму и все её внутренние элементы (кнопки, текст и тд)
/// </summary>
public class PanoramaElement : MonoBehaviour
{
    public AllPanoramas allPanoramas;
    public GameObject localElements;
    
    public Panorama panorama;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = allPanoramas.audioSource;
    }

    public void ChangePanorama()
    {
        RenderSettings.skybox = panorama.mat;
        if(panorama.audioClip != null)
        {
            audioSource.clip = panorama.audioClip;
            audioSource.Play();
        }
        localElements.SetActive(true);
    }



}
