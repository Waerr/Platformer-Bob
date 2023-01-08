using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public Sprite blockSprite;
    public Sprite unblockSprite;
    public LeverController leverController;
    public GameObject[] blocks;
    
    public static BlockController instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (leverController.leverTurned)
        {
            for(int i = 0; i < blocks.Length; i++)
            {
                blocks[i].GetComponent<SpriteRenderer>().sprite = blockSprite;
                blocks[i].GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (!leverController.leverTurned)
        {
            for(int i = 0; i < blocks.Length; i++)
            {
                blocks[i].GetComponent<SpriteRenderer>().sprite = unblockSprite;
                blocks[i].GetComponent<BoxCollider2D>().enabled = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}

