using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public SceneFader fader;

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
        Time.timeScale = 1;
    }
    
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        
    } 
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }
    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        TimerController.instance.BeginTimer();
    }

}