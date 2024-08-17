using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float Dash = 100; // Charge Attack

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if(Input.GetKey("w")){
            Debug.Log("W pressed");
            transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
        }
        if(Input.GetKey("s")){
            transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
        }
        if(Input.GetKey("a")){
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }
        if(Input.GetKey("d")){
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
    }
}
