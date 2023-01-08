using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class TimerController : MonoBehaviour
{
    
    
    public static TimerController instance;
    public Text timeCounter;
    public Text timerEnd;
    private TimeSpan timePlaying;
    public bool timerGoing;
    private float elapsedTime;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
        Time.timeScale = 0;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
 
            yield return null;
        }
        if (!timerGoing)
        {
            string timePlayingStr = "Time Taken: " + timePlaying.ToString("mm':'ss'.'ff");
            timerEnd.text = timePlayingStr;
            
        }
    }
}

