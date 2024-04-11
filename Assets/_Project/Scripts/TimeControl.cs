using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI pauseTimerText;
    float time = 0;
    int min, sec, ten;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        min = Mathf.FloorToInt(time / 60);
        sec = Mathf.FloorToInt(time % 60);
        ten = Mathf.FloorToInt((time % 1) * 100);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, ten);
    }

    public void PauseGame()
    {
        pauseTimerText.text = timerText.text;
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    
}
