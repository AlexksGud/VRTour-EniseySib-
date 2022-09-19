using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Хранение всех панорам и источника звука
/// </summary>
public class AllPanoramas : MonoBehaviour
{
    public List<PanoramaElement> allElements;
    public AudioSource audioSource;

    private void Start()
    {
        DisableAll();
        Activate(2);
    }

    public void DisableAll()
    {
        foreach (var allPanorama in allElements)
        {
            allPanorama.localElements.SetActive(false);
        }
    }

    public void Activate(int id)
    {
        DisableAll();
        allElements[id].ChangePanorama();
    }
}
