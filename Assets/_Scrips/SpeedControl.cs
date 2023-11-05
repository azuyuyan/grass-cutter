using FluffyUnderware.Curvy.Controllers;
using FluffyUnderware.Curvy.Generator;
using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    PathController path;
    ReadColorTest readColorTest;
    void Start()
    {
        readColorTest=FindObjectOfType<ReadColorTest>();
        path = GetComponent<PathController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GrassArea"))
        {
            path.Speed = 2;
            readColorTest.quadCounter=other.GetComponent<P3dChangeCounter>();
            readColorTest.quadCounterEvent=other.GetComponent<P3dChangeCounterEvent>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GrassArea"))
        {
            path.Speed = 5;
            readColorTest.quadCounter = null;
            readColorTest.quadCounterEvent=null;
        }
    }
}
