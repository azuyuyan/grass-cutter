using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSwords : MonoBehaviour
{
    public Transform parentSword;
    public Transform scaleCapsule;
    public FlightControll flightControll;
    void Start()
    {
        flightControll=FindObjectOfType<FlightControll>();
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
                flightControll.power += 0.022f;
            }
            else
            {
                
                flightControll.power += 0.022f;
            }
            


        }
       
    }
}
