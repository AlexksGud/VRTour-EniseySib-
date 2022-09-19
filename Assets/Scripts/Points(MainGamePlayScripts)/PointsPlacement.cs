using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsPlacement : MonoBehaviour
{

    [SerializeField] private PointsPlacement[] _points;
    [SerializeField] private Panorama pano;
    [SerializeField] private PanoramaElements UIElements;

    public float delay = 0.6f;


    private void Start()
    {
        if (!UIElements.firstPoint)
        {
            UIElements.gameObject.SetActive(true);
            UIElements.SetVisible(false,0.1f);
        }
    }
    public void ClickOnPoint()
    {
        StartCoroutine(SkyBoxChange());
        StartCoroutine(UIChange(true));
    }
    private void HideUI()
    {
        StartCoroutine(UIChange(false));
    }

    IEnumerator SkyBoxChange()
    {
        Points.instance.CurrentPoint().HideUI();
        // postprocess
        yield return new WaitForSeconds(delay);

        RenderSettings.skybox = pano.mat;
        Points.instance.SavePoint(this);

    }
    IEnumerator UIChange(bool show)
    {

        UIElements.SetVisible(show,delay);
        yield return null;
    }

}
