using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    }
    // Update is called once per frame
    void Update()
    {
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
        }
    }
}
