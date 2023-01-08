using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // Define GameObjects to be accessible within the script.
    private Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    private Transform taker;
    public GameObject Door;
    public SpriteRenderer LeverSprite;
    public Sprite LeverTurned;
    public GameObject LevelComplete;
    public GameObject DuringLevel;
    public GameObject RestartLevel;
    public bool completeLevel;
    
    public Animator animator;

    // Variables used within the script.
    private bool m_FacingRight = true;
    private float lockPos = 0f;
    private string timerFinal;
    private float moveHorizontal;
    public float moveSpeed = 10f;
    public float jumpForce;
    private Vector3 movement;
    private bool canJump;
    private bool jump;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] [Range(0, 1f)] private float movementSmoothing = .05f;
    [SerializeField] private KeyScript keyController;
    [SerializeField] private LayerMask groundLayer;
    
    
    [SerializeField] private LayerMask itemLayer;

    // Start is called before the first frame update

    void Start()
    {
        
        LevelComplete.SetActive(false);
        RestartLevel.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        completeLevel = false;
        GameController.gc.gameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
        }
        
        
        if(IsGrounded())
        {
            animator.SetBool("isJumping", false);
        }
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
    }

    private void FixedUpdate()
    {
        if (Door.activeInHierarchy && keyController.keyPickedUp)
        {
            Door.SetActive(false);
        }
        else if (!Door.activeInHierarchy && !keyController.keyPickedUp)
        {
            Door.SetActive(true);
        }

        Movement((moveHorizontal * Time.fixedDeltaTime), jump);
        jump = false;

    

    }



    private bool IsGrounded()
    {
        float extraLength = .03f;
        var bounds = boxCollider.bounds;
        RaycastHit2D hit =
            Physics2D.Raycast(bounds.center, Vector2.down, (bounds.extents.y + extraLength), groundLayer);


        if (hit.collider != null)
        {
            return true;
        }

        return hit.collider != null;
    }

    public void Movement(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);


        if (move > 0 && !m_FacingRight){
            Flip();
        }

        else if (move < 0 && m_FacingRight){
            Flip();
        }



        if (IsGrounded() && jump)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            animator.SetBool("isJumping", true);
            FindObjectOfType<AudioManager>().Play("Jump");
        }

    }

    public bool IsInRange()
    {
        float extraLength = 0.03f;
        var bounds = boxCollider.bounds;
        RaycastHit2D hit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.left, extraLength, itemLayer);
        RaycastHit2D hit1 = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.right, extraLength, itemLayer);

        if (hit.collider != null || hit1.collider != null)
        {
            return true;
        }

        return hit.collider != null || hit1.collider != null;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Lever = GameObject.Find("Lever");

        
        
        if (other.gameObject.name == "NextLevel" && keyController.keyPickedUp)
        {
            completeLevel = true;
            LevelComplete.SetActive(true);
            DuringLevel.SetActive(false);
            GameController.gc.gameStart = false;
        }
        else if (other.gameObject.name == "RestartLevel")
        {
            TimerController.instance.EndTimer();
            RestartLevel.SetActive(true);
        }
        
    }
    private void Flip(){
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
