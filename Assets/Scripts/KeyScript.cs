using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    
    public PlayerController controller;
    [SerializeField] private Transform taker;
    public bool keyPickedUp;
    public Animator animator;
    private int num = 1;
    float timer = 1f;
    float delay = 1f;
    private float lockPos = 0f;

    // Update is called once per frame
    void Update()
    {
        
       transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
        
        timer -= Time.deltaTime;
        // If the timer is 0 allows the player to drop or pickup the key
        if (timer <= 0)
        {
            // when Q is pressed and the player is in Range, the gameobject is attached to the player and it's position is manipulated to be above
            if (Input.GetKey(KeyCode.Q) && controller.IsInRange() && (num % 2) == 1)
            {
                animator.SetBool("keyPickedUp", true);
                keyPickedUp = true;
                transform.parent = taker;
                transform.position =
                    new Vector2(controller.transform.position.x, controller.transform.position.y + 1f);
                
                // Allows the same key to be pressed to pick and drop the key
                num += 1;
                timer = delay;
            }
            else if (Input.GetKey(KeyCode.Q) && (num % 2) == 0)
            {
                animator.SetBool("keyPickedUp", false);
                keyPickedUp = false;
                transform.parent = null;
                num -= 1;
                timer = delay;
            }
        }
    }

}

