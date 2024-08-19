using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float HealthPoint = 100;
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
    }

    // Update is called once per frame
    void Update()
    {
        //Check if Player is Dead
        if(this.HealthPoint == 0){
            Destroy(this);
        }

        //MovingAnimation
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
        if(collision.gameObject.tag == "Bullet"){
            //TakeDamage
            this.HealthPoint--;
        }
    }
    public void TakeDamage(float damage){
        this.HealthPoint -= damage;
    }
}