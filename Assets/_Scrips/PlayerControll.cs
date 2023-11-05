using DG.Tweening;
using FluffyUnderware.Curvy.Controllers;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public List<Transform> slots = new List<Transform>();
    public float speed;
    public float rotateSpeed;
    public PathController pathcontroller;
    public bool isStart;
    public bool isAnimated;
    public bool isFinih;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameStart()
    {
        pathcontroller.Speed = speed;
        isStart = true;
        rotateSpeed = 5;
    }
    public void AddSlot(Transform t)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].childCount == 0)
            {
                t.GetComponent<RotateAround>().Activated();
                t.SetParent(slots[i]);
                t.DOLocalMove(new Vector3(0, 0.2f, 0), 0.3f);
                t.DOLocalRotate(new Vector3(0, 0, 0), 0.4f);
                t.DOScale(new Vector3(0.57f, 0.57f, 0.57f), 0.4f);
                t.GetChild(0).GetComponent<PaintRadChange>().enabled = true;
                WeaponAnim();
                break;
            }
        }
        
        
    }
    public void WeaponAnim()
    {
        if(isAnimated==false)
        {
            isAnimated = true;
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].DOShakeScale(0.2f, slots[1].localScale).OnComplete(() => { isAnimated = false; });

            }
        }
        
    }
    public void ScaleUp()
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].localScale=new Vector3(slots[i].localScale.x + 0.2f, slots[i].localScale.y + 0.2f, slots[i].localScale.z + 0.2f);
        }
        WeaponAnim();

    }
    public void ScaleDown()
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Failure);
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].localScale=new Vector3(slots[i].localScale.x - 0.2f, slots[i].localScale.y - 0.2f, slots[i].localScale.z - 0.2f);
        }
        WeaponAnim();
    }
    public void SpeedUp()
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
        rotateSpeed += 2;
        WeaponAnim();
    }
    public void SpeedDown()
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Failure);
        rotateSpeed -= 1;
        WeaponAnim();
    }
    public void ReachToFinish()
    {
        GetComponent<PathController>().enabled = false;
        speed= 0;
    }
}
