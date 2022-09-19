using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixMSAA : MonoBehaviour
{
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
        StartCoroutine("MSAAFix");
        QualitySettings.antiAliasing = 4;
        UnityEngine.XR.XRDevice.UpdateEyeTextureMSAASetting();
        //Debug.LogError(UnityEngine.XR.XRSettings.eyeTextureDesc.msaaSamples);
    }

    /// <summary>
    /// Fixes MSAA not being applied in VR with URP. Taken from; https://forum.unity.com/threads/quest-lwrp-urp-msaa-not-working.786026/
    /// </summary>
    /// <returns></returns>
    IEnumerator MSAAFix()
    {
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 0.5f; // Any value, just to trigger the refresh
        yield return new WaitForEndOfFrame(); // Needed to apply the changes
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 2f; // Use your target resolution here
        //Debug.LogError("after: " + UnityEngine.XR.XRSettings.eyeTextureDesc.msaaSamples);
        yield return null;
    }
}
