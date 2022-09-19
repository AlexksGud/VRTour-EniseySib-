using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenPanelXR : MonoBehaviour
{
    public XRNode inputSource;
    public bool secondaryButton;
    public bool isPressed;

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButton);
        
        device.IsPressed(InputHelpers.Button.SecondaryButton, out isPressed, 0);

        panel.SetActive(secondaryButton);
    }
}
