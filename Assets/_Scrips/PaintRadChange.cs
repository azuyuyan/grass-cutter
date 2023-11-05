using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintRadChange : MonoBehaviour
{
    Transform parentScale;
    P3dPaintSphere radius;
    void Start()
    {
        parentScale=transform.parent.parent;
        radius=GetComponent<P3dPaintSphere>();
    }

    // Update is called once per frame
    void Update()
    {
        radius.Radius = parentScale.localScale.x / 5;
    }
}
