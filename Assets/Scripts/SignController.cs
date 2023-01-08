using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SignController : MonoBehaviour
{
    public GameObject SignBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool playerInRange;
    private bool SignAct;

    
    void Start()
    {
        
    }


    void Update()
    {
        if (!SignAct && playerInRange)
        {
            if (SignBox.activeInHierarchy)
            {
                SignBox.SetActive(false);
                SignAct = false;
            }
            else
            {
                SignBox.SetActive(true);
                SignAct = true;
                dialogText.text = dialog;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            SignBox.SetActive(false);
            SignAct = false;
        }
    }

}
