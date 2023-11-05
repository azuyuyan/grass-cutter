using FluffyUnderware.DevTools.Extensions;
using Lofelt.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchToMaterial : MonoBehaviour
{
    public Material confetti;
    public GameObject fx1, fx2;
    UiManager uiManager;
    public int score;
    void Start()
    {
        uiManager=FindObjectOfType<UiManager>();
        score=int.Parse( transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Replace()
    {
        //GetComponent<MeshRenderer>().materials.Add(null);
        //var list = new Material[GetComponent<MeshRenderer>().materials.Length];
        //list[0] = GetComponent<MeshRenderer>().materials[0];
        //list[1] = confetti;
        //GetComponent<MeshRenderer>().materials = list;
        fx1.SetActive(true);
        fx2.SetActive(true);
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.SoftImpact);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Replace();
            uiManager.score=score;
            
        }
    }
}
