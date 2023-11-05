using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    PlayerControll playerControll;
    public GameObject gameStartText;
    public GameObject joystick;
    public GameObject confetti;
    public int score;
    public int record;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI recordScoreText;
    public GameObject finishParticle;
    public GameObject finishPanel;
    void Start()
    {
        record = PlayerPrefs.GetInt("record", record);
        playerControll =FindObjectOfType<PlayerControll>();
        Invoke("GetUiObjectsFromStart", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        playerControll.GameStart();
        gameStartText.SetActive(false);
    }
    public void GetUiObjectsFromStart()
    {
        gameStartText.SetActive(true);
        joystick.SetActive(true);
    }
    public void FinishPanelOpen()
    {
        finishPanel.SetActive(true);
        finishParticle.SetActive(true);
        scoreText.text = score.ToString();
        if(record>score)
        {
            record = PlayerPrefs.GetInt("record",record);
            recordScoreText.text=record.ToString();
        }
        else
        {
            record=score;
            PlayerPrefs.SetInt("record",record);
            recordScoreText.text = record.ToString();
        }
    }
}
