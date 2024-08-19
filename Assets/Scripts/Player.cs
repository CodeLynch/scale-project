using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
<<<<<<< HEAD
    public Rigidbody2D rb;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float dashSpeed = 0f;
    [SerializeField] private float dashLenght = 0.5f , DashOnCooldown = 1f;
    
    private Vector2 moveInput;
    private float activeSpeed;
    private float dashCounter;
    private float dashCoolCounter;

    void Start(){
        activeSpeed = speed;
=======
    [Header("Properties")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float Dash = 100; // Charge Attack
    [SerializeField] private float growthRate = 0.2f;
    [SerializeField] private float maxSize = 2f;
    [SerializeField] private AnimationClip IdleAnim;
    [SerializeField] private AnimationClip RunHorizAnim;
    [SerializeField] private AnimationClip RunTopAnim;
    [SerializeField] private AnimationClip RunBottomAnim;

    [Header("Public Attributes")]
    public float size = 1;
    private bool faceRight = true;
    private bool isMoving = false;
    private Animator anim;
    private string currentAnim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
>>>>>>> main
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        //Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        moveInput.Normalize();
        rb.velocity = moveInput * activeSpeed;
        
        if(Input.GetKeyDown(KeyCode.Space)){
            if(dashCoolCounter <= 0 && dashCounter <=0){
                activeSpeed = dashSpeed;
                dashCounter = dashLenght;
            }
        }
        if(dashCounter > 0){
            dashCounter -= Time.deltaTime;
            if(dashCounter <= 0){
                activeSpeed = speed;
                dashCoolCounter = dashCounter;
            }
        }
        if(dashCoolCounter > 0){
            dashCoolCounter -= Time.deltaTime;
=======

        if (!isMoving)
        {
            changeAnim(IdleAnim.name);
        }
        if(size > 1 && size <= maxSize)
        {
            transform.localScale = new Vector2 (size, size);
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            isMoving = true;
            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            {
                changeAnim(RunHorizAnim.name);
                if (Input.GetAxisRaw("Horizontal") == 1)
                {

                    transform.localScale = new Vector2(size, size);
                }
                else
                {
                    transform.localScale = new Vector2(-size, size);
                }
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (Input.GetAxisRaw("Vertical") == 1)
                {
                    changeAnim(RunTopAnim.name);
                }
                else
                {
                    changeAnim(RunBottomAnim.name);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") != 0)
            {
                changeAnim(RunHorizAnim.name);
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    transform.localScale = new Vector2(size, size);
                }
                else
                {
                    transform.localScale = new Vector2(-size, size);
                }
            }
        }
        else
        {
            isMoving = false;
        }


            //Movement
        if (Input.GetKey("w")) {
                transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            }
        if (Input.GetKey("s")) {
                transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            }
        if (Input.GetKey("a")) {
                transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            }
        if (Input.GetKey("d")) {
                transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            }
        

    }
    private void changeAnim(string state)
    {
        if (currentAnim == state)
        {
            return;
        }
        else
        {
            anim.Play(state);
>>>>>>> main
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fruit")
        {
            if(size <= maxSize)
            {
                size += growthRate;
                Camera.main.orthographicSize += 1;
            }
            Destroy(collision.gameObject);
        }
    }
}