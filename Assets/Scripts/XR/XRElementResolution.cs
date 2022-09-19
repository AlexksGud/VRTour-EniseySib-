using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XRElementResolution : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Button btnIncrease;
    public Button btnDecrease;
    public Slider slider;

    public string valueName;
    
    public float value;
    public float increaseValue;
    public float decreaseValue;


    void Start()
    {
        btnIncrease.onClick.AddListener(IncreaseValue);
        btnDecrease.onClick.AddListener(DecreaseValue);
        slider.onValueChanged.AddListener(delegate { ChangeValue(); });
    }
    
    public void UpdateElement(){
        btnIncrease.GetComponentInChildren<TextMeshProUGUI>().text = "Увеличить на " + increaseValue;
        btnDecrease.GetComponentInChildren<TextMeshProUGUI>().text = "Уменьшить на " + decreaseValue;
        slider.value = value;
    }

    private void Update()
    {
        text.text = valueName + ": " + value;
    }

    void ChangeValue()
    {
        value = slider.value;
    }

    void IncreaseValue()
    {
        value += increaseValue;
        UpdateElement();
    }
    void DecreaseValue()
    {
        value -= decreaseValue;
        UpdateElement();
    }
}
