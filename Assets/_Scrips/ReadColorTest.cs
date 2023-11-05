using FluffyUnderware.DevTools.Extensions;
using Lofelt.NiceVibrations;
using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofelt.NiceVibrations;
public class ReadColorTest : MonoBehaviour
{
    public P3dChangeCounter quadCounter;
    public P3dChangeCounterEvent quadCounterEvent;
    public GameObject prefab;
    public Transform insPos;
    FollowSwords followSwords;
    
    void Start()
    {
        followSwords=FindObjectOfType<FollowSwords>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(quadCounter != null||quadCounterEvent!=null)
        {
            if (quadCounterEvent.Ratio > quadCounterEvent.Range.y)
            {
                Test();
                
            }
        }
        
    }
    public void Test()
    {
        print("ColorTest");
        quadCounterEvent.Range = new Vector2(0,quadCounterEvent.Ratio+0.007f) ;
        followSwords.ScaledCap();
        GameObject go = Instantiate(prefab, insPos);
        
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.RigidImpact);
       

        Destroy(go,2);
       



    }
}
