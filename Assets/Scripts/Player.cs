using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float Dash = 100; // Charge Attack
    [SerializeField] public float growthRate = 0.2f;
    [SerializeField] private float maxSize = 2f;
    [SerializeField] private float DashSpeed;
    [SerializeField] private float DashCooldown;
    [SerializeField] private float DashDuration;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private AnimationClip IdleAnim;
    [SerializeField] private AnimationClip RunHorizAnim;
    [SerializeField] private AnimationClip RunTopAnim;
    [SerializeField] private AnimationClip RunBottomAnim;


    [Header("Public Attributes")]
    public float size = 1;
    private float origDashDuration;
    private float origDashCooldown;
    private bool faceRight = true;
    private bool isMoving = false;
    private bool isDashing = false;
    private bool onDashCoolDown = false;
    private Animator anim;
    private string currentAnim;
    private Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        origDashDuration = DashDuration;
        origDashCooldown = DashCooldown;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isMoving)
        {
            changeAnim(IdleAnim.name);
        }
        if (size > 1 && size <= maxSize)
        {
            transform.localScale = new Vector2(size, size);
            trail.widthMultiplier = size;
            trail.time = size;
        }
        else
        {
            trail.widthMultiplier = size;
            trail.time = size;
        }

        
        if(transform.localScale.x < 0)
        {
            faceRight = false;
        }
        else
        {
            faceRight = true;
        }




        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 || Input.GetKey(KeyCode.Space))
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
            if (faceRight)
            {
                faceRight = false;
            }
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            }
        if (Input.GetKey("d")) {
            if (!faceRight)
            {
                faceRight = true;
            }
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            }

        if (Input.GetKey(KeyCode.Space) && DashCooldown == origDashCooldown && !onDashCoolDown)
        {
            isDashing = true;
        }
        else if (onDashCoolDown)
        {
            if(DashCooldown <= 0)
            {
                DashCooldown = origDashCooldown;
                onDashCoolDown = false;
            }
            else
            {
                DashCooldown -= Time.deltaTime;
            }
        }

        if (isDashing)
        {
            if (DashDuration <= 0)
            {
                isDashing = false;
                DashDuration = origDashDuration;
                rb.velocity = Vector2.zero;
                onDashCoolDown = true;
                trail.emitting = false;
            }
            else
            {
                trail.emitting = true;
                DashDuration -= Time.deltaTime;
                if (Input.GetAxisRaw("Vertical") != 0)
                {
                    if (Input.GetAxisRaw("Vertical") == 1)
                    {
                        rb.velocity = Vector2.up * DashSpeed;
                    }
                    else
                    {
                        rb.velocity = Vector2.down * DashSpeed;
                    }
                }
                else
                {

                    if (faceRight)
                    {
                        rb.velocity = Vector2.right * DashSpeed;
                    }
                    else
                    {
                        rb.velocity = Vector2.left * DashSpeed;
                    }
                }
            }
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fruit")
        {
            Fruit fruit = collision.gameObject.GetComponent<Fruit>();
            if(size <= maxSize)
            {
                size += growthRate * fruit.fruitValue;
                //Camera.main.orthographicSize += 1;
            }
            Destroy(collision.gameObject);
        }
    }
}