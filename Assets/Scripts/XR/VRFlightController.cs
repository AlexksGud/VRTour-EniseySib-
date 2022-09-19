using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRFlightController : XRBaseInteractable
{
    public float PitchValue;
    public float RollValue;
    public TMP_Text[] texts;
    public bool isSelected = false;

    public GameObject Controller;

    private void Update()
    {
        if (isSelected)
        {
            PitchValue = Mathf.Clamp(Controller.transform.localRotation.x * 2, -1, 1);
            RollValue = Mathf.Clamp(Controller.transform.localRotation.z * 2, -1, 1);

            texts[0].text = "PitchValue: " + PitchValue.ToString();
            texts[1].text = "RollValue: " + RollValue.ToString();
        }
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);
        Controller = interactor.gameObject;
        isSelected = true;
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor)
    {
        base.OnSelectExiting(interactor);
        isSelected = false;
    }

}
