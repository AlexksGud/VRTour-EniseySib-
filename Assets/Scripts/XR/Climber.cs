using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    private ContunuousMovement contunuousMovement;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        contunuousMovement = GetComponent<ContunuousMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(climbingHand)
        {
            contunuousMovement.enabled = false;
            Climb();
        }
        else
        {
            contunuousMovement.enabled = true;
        }
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
