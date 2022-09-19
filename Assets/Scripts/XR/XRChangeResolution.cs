using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class XRChangeResolution : MonoBehaviour
{
    
    [Serializable]
    public class Elements
    {
        public XRElementResolution element;
        public string valueName;
        public float value;
        public float increaseValue;
        public float decreaseValue;
    }

    public List<Elements> ElementsList;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in ElementsList)      
        {
            item.element.valueName = item.valueName;
            item.element.value = item.value;
            item.element.increaseValue = item.increaseValue;
            item.element.decreaseValue = item.decreaseValue;
            item.element.UpdateElement();
        }
        //ElementsList[0].element.value = XRSettings.eyeTextureResolutionScale;
        ElementsList[0].element.value = 2;
        ElementsList[1].element.value = XRSettings.occlusionMaskScale;
        ElementsList[2].element.value = XRSettings.renderViewportScale;
    }

    // Update is called once per frame
    void Update()
    {
        XRSettings.eyeTextureResolutionScale = ElementsList[0].element.value;
        XRSettings.occlusionMaskScale = ElementsList[1].element.value;
        XRSettings.renderViewportScale = ElementsList[2].element.value;
    }

}
