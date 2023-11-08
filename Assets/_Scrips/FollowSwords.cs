using Lofelt.NiceVibrations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowSwords : MonoBehaviour
{
    public Transform parentSword;
    public Transform scaleCapsule;
    public FlightControl flightControl;
    public TextMeshProUGUI powerText;
    void Start()
    {
        flightControl=FindObjectOfType<FlightControl>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition=new Vector3(parentSword.localPosition.x,transform.localPosition.y,transform.localPosition.z);
    }
    public void ScaledCap()
    {
        StartCoroutine(delay());
        IEnumerator delay()
        {
            yield return new WaitForSeconds(1);
            if (scaleCapsule.localScale.y < 1f)
            {
                
                scaleCapsule.localScale = new Vector3(scaleCapsule.localScale.x, scaleCapsule.localScale.y + 0.006f, scaleCapsule.localScale.z);
                flightControl.power += 0.022f;
                powerText.text = MathF.Round (flightControl.power * 28).ToString();
            }
            else
            {
                
                flightControl.power += 0.022f;
                powerText.text = MathF.Round(flightControl.power * 28).ToString();
            }
            


        }
       
    }
}
