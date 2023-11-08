using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlightControl : MonoBehaviour
{
    public float power;
    public Transform fuelY;
    PlayerControll playerControl;
    public GameObject cam1, cam2;
    public GameObject fx1, fx2;
    UiManager uiManager;
    void Start()
    {
        playerControl=FindObjectOfType<PlayerControll>();
        uiManager=FindObjectOfType<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CalculateFuel()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        power *= 100;
        playerControl.transform.DOMoveY(power,8).SetEase(Ease.InOutFlash);
        fuelY.DOScaleY(0.000f, 8).OnComplete(() =>
        { 
        uiManager.FinishPanelOpen();
        });
        fx1.SetActive(true);
        fx2.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
