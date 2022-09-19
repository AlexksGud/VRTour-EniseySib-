using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public Transform obj;
    public Vector3 respawnPos;

    public float range = 100f;
    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Transform>();
        respawnPos = obj.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(obj.position.y) - Mathf.Abs(respawnPos.y) > range)
        {
            obj.position = respawnPos;
            obj.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            obj.gameObject.GetComponent<CharacterController>().velocity.Set(0, 0, 0);
        }
    }
}
