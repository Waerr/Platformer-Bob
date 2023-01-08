using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelSelectController : MonoBehaviour
{
    public SceneFader fader;

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
    
    void Update()
    {
        
    }
}

