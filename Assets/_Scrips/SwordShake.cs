using DG.Tweening;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordShake : MonoBehaviour
{
    Transform parentObj;
    public float zChange;
    public Joystick joystick;
    public float shakeSpeed;
    public float tempSpeed;
    public PlayerControll playerControll;
    FlightControl lightControll;
    public Transform landingPart1, landingPart2,capsule;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;
    }
    void Start()
    {
        lightControll=FindObjectOfType<FlightControl>();
        playerControll=FindObjectOfType<PlayerControll>();
        parentObj=transform.parent.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        tempSpeed = playerControll.rotateSpeed;
        if (playerControll.isFinih == false)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + joystick.Horizontal * Time.deltaTime * shakeSpeed, transform.localPosition.y, 0);
        }
        
       

        var pos = transform.localPosition;
        pos.x = Mathf.Clamp(transform.localPosition.x, -4, 4);
        transform.localPosition = pos;
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, tempSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
           
            playerControll.AddSlot(other.transform);
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
        }
        if (other.gameObject.CompareTag("Gate"))
        {
            other.GetComponent<GateControll>().Activated();
            if(other.GetComponent<GateControll>().type==GateType.Scale)
            {
                if(other.GetComponent<GateControll>().value<0) 
                { 
                    playerControll.ScaleDown();
                }
                else
                {
                    playerControll.ScaleUp();
                }
            }
            else
            {
                if (other.GetComponent<GateControll>().value < 0)
                {
                    playerControll.SpeedDown();
                }
                else
                {
                    playerControll.SpeedUp();
                }
            }
            
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            
            playerControll.isFinih=true;
            playerControll.ReachToFinish();
            playerControll.transform.DOMove(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), 1);
            transform.DOLocalMove(new Vector3(0, transform.position.y, transform.localPosition.z), 1).OnComplete(() =>
            { 
                for(int i = 0; i < playerControll.slots.Count; i++)
                {
                    if (playerControll.slots[i].childCount > 0)
                    {
                        playerControll.slots[i].GetChild(0).DOLocalMoveY(playerControll.slots[i].GetChild(0).localPosition.x + 50, 2);
                    }
                   
                    Destroy(playerControll.slots[i].gameObject,2.1f);
                }
            landingPart1.DOScale(new Vector3(0.198877171f, 0.147818655f, 0.198877215f), 1);
                landingPart2.DOScale(new Vector3(0.456583291f, 0.33936277f, 0.456583261f), 1);
                capsule.DOLocalMoveY(0.95f, 1);
                lightControll.CalculateFuel();
            });
            
        }
    }

}
