using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
    [SerializeField] private AnimationClip IdleTopAnim;
    [SerializeField] private AnimationClip IdleBottomAnim;
    [SerializeField] private AnimationClip RunHorizAnim;
    [SerializeField] private AnimationClip RunTopAnim;
    [SerializeField] private AnimationClip RunBottomAnim;


    [Header("Public Attributes")]
    public float size = 1;
    
    private float origDashDuration;
    private float origDashCooldown;
    
    /*Face Direction Values:
    //1 for up
    //2 for right
    //3 for down
    //4 for left
    */
    private short faceDir = 2;
    
    private bool isMoving = false;
    private bool isDashing = false;
    private bool onDashCoolDown = false;
    private Animator anim;
    private string currentAnim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isFlashing = false;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        origDashDuration = DashDuration;
        origDashCooldown = DashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        //MovingAnimation
        if (!isMoving)
        {
            UpdateFacing(faceDir);
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
            faceDir = 1;
                transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            }
        if (Input.GetKey("s")) {
            faceDir = 3;
                transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            }
        if (Input.GetKey("a")) {
            faceDir = 4;
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            }
        if (Input.GetKey("d")) {
            faceDir = 2;
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            }

        if (Input.GetKey(KeyCode.Space) && DashCooldown == origDashCooldown && !onDashCoolDown && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
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

                    if (faceDir == 2)
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
        else
        {
            trail.emitting = false;
        }
        

    }

    private void UpdateFacing(short face)
    {
        switch (face) {
            case 1:
                changeAnim(IdleTopAnim.name);
                break;
            case 2:
                transform.localScale = new Vector2(size, size);
                changeAnim(IdleAnim.name);
                break;
            case 3:
                changeAnim(IdleBottomAnim.name);
                break;
            case 4:
                transform.localScale = new Vector2(-size, size);
                changeAnim(IdleAnim.name);
                break;
            default: break;
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
        if (collision.gameObject.tag == "Fruit")
        {
            Fruit fruit = collision.gameObject.GetComponent<Fruit>();
            if (size <= maxSize)
            {
                size += growthRate * fruit.fruitValue;
            }
            if (!isFlashing)
            {
                isFlashing = true;
                StartCoroutine(Flash(Color.green));
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Cage")
        {
            if (size >= maxSize && collision.relativeVelocity.magnitude >= 20)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                rb.AddForce((Vector2.Reflect(rb.velocity, collision.contacts[0].normal) * 10), ForceMode2D.Impulse);
            }
        }
        if(collision.gameObject.tag == "Enemy"){
            if (!isFlashing)
            {
                isFlashing = true;
                StartCoroutine(Flash(Color.red));
            }
            if(size<=1){
                Destroy(this);
            } else {
                this.size -= growthRate;
            }
        }
    }

    private IEnumerator Flash(Color color)
    {
        sr.color = color;
        yield return new WaitForSeconds(.5f);
        sr.color = Color.white;
        isFlashing = false;

    }
}