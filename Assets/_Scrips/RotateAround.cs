using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    
    public GameObject fx;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.2f, 0);
    }
    public void Activated()
    {
        fx.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        enabled = false;
        
        
    }
}
