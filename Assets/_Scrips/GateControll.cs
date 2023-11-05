using DG.Tweening;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GateType
{
    Spin,Scale
}
public class GateControll : MonoBehaviour
{
    public int value;
    public GameObject redDoor, greenDoor;
    public GameObject scaleUp,ScaleDown, spinImg,speedDown,SpeedUp;
    public GateType type;
    public BoxCollider orherGate;
    public TextMeshProUGUI nameText;
    void Start()
    {
        scaleUp.SetActive(false);
        ScaleDown.SetActive(false);
        spinImg.SetActive(false);
        speedDown.SetActive(false);
        SpeedUp.SetActive(false);
        redDoor.SetActive(false);
        greenDoor.SetActive(false);
        if(type == GateType.Scale)
        {
            if (value < 0)
            {
                ScaleDown.SetActive(true);
                redDoor.SetActive(true);
                nameText.text = "Shrink!";
               
            }
            else
            {
                scaleUp.SetActive(true);
                greenDoor.SetActive(true);
                nameText.text = "ScaleUP!";
                
            }
            

        }
        else
        {
            if (value < 0)
            {
                spinImg.SetActive(true);
                speedDown.SetActive(true);
                redDoor.SetActive(true) ;
                nameText.text = "Slow!";
                
            }
            else
            {
                spinImg.SetActive(true);
                SpeedUp.SetActive(true);
                greenDoor.SetActive(true);
                nameText.text = "SpinUP!";
               
            }

        }
        if (value < 0)
        {
            greenDoor.SetActive(false);
        }
        else
        {
            redDoor.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Activated()
    {
        orherGate.enabled = false;
        transform.DOMoveY(transform.position.y - 4,0.3f);
        orherGate.GetComponent<Transform>().DOMoveY(transform.position.y - 4, 0.3f);
    }
}
