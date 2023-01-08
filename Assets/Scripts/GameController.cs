using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gc;
    public bool gameStart;
    
    // Start is called before the first frame update
    private void Awake(){
        
        
        
        gc = this;
        
        
        
    }
    
    void Start(){
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameStart && !TimerController.instance.timerGoing)
        {
            TimerController.instance.BeginTimer();
        }

        if (!gameStart){
            TimerController.instance.EndTimer();
        }
    
    
    
    }


}
