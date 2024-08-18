using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float Dash = 100; // Charge Attack
    [SerializeField] private AnimationClip IdleAnim;
    [SerializeField] private AnimationClip RunHorizAnim;
    [SerializeField] private AnimationClip RunTopAnim;
    [SerializeField] private AnimationClip RunBottomAnim;


    private bool faceRight = true;
    private bool isMoving = false;
    private Animator anim;
    private string currentAnim;
    // Health thresholds (S = 0~40, M = 41~ 70, L = 71~100)
    public int maxHealth = 100;
    public int currentHealth = 30;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isMoving)
        {
            changeAnim(IdleAnim.name);
        }


        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            isMoving = true;
            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            {
                changeAnim(RunHorizAnim.name);
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    transform.localScale = new Vector2(-1, 1);
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
                    transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    transform.localScale = new Vector2(-1, 1);
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
    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            // Gameover logic here
        }
    }
    void Heal(int amount)
    {
        currentHealth += amount;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Items"))
        {
            Heal(10);
            Destroy(collision.gameObject);
        }
    }
}