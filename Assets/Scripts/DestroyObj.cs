using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public TMP_Text text;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grabing()
    {
        text.text += "Ты молодец";
        Destroy(gameObject);
    }
}
