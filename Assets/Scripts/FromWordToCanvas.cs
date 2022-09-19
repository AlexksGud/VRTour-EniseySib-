using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FromWordToCanvas : MonoBehaviour
{
    public Transform WorldObj;
    RectTransform CanvasPosition;
    Image image;
    Camera _camera;
    float WidthCentr = 960;
    float heghtCenrt = 540;
    private Text _text;
    float transparentSize = 200;

    private Color White;

    private Color transparentColor;
    // Use this for initialization
    void Start()
    {
         transparentColor = new Color(255,255,255,0);
         White = new Color(255,255,255,1);
        _text = null;
        image = GetComponent<Image>();
        _text = GetComponentInChildren<Text>();
        CanvasPosition = GetComponent<RectTransform>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        image.color = transparentColor;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = _camera.WorldToViewportPoint(WorldObj.position);
//        Debug.Log(position);

        if (position.z > 0)
        {
            position =_camera.WorldToScreenPoint(WorldObj.position);
            Vector3 center = new Vector3(WidthCentr, heghtCenrt, position.z);
            float transparent = transparentSize / Vector3.Distance(center, position);
            if (transparent > 1)
                transparent = 1;
            //Debug.Log(transparent);
            image.color = new Color(255,255,255,transparent);
            CanvasPosition.localScale = Vector3.one * transparent;
            CanvasPosition.anchoredPosition = position;
            if(_text!=null)
                _text.color = new Color(255,255,255,transparent);
        }
        else
        {image.color = transparentColor;
            CanvasPosition.anchoredPosition = position;
            if(_text!=null)
            _text.color = transparentColor;
        }
    }
}