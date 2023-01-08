using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public SpriteRenderer leverSprite;
    public Sprite leverToggled;
    public Sprite leverUntoggled;
    public bool leverTurned = false;
    private bool isInRange;
    private int num = 1;
    float timer = 1f;
    float delay = 1f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (Input.GetKey(KeyCode.E) && isInRange & (num % 2) == 1)
            {
                leverSprite.sprite = leverToggled;
                leverTurned = true;
                num += 1;
                timer = delay;
            }
            else if (Input.GetKey(KeyCode.E) && isInRange && leverTurned && (num % 2) == 0)
            {
                leverSprite.sprite = leverUntoggled;
                leverTurned = false;
                num -= 1;
                timer = delay;

            }
        }
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
        
    }
    
    
    
}
