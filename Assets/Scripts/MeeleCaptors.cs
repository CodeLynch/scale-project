using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleCaptors : MonoBehaviour
{
    [Header ("Properties")]
    //Made this into private since once this is initialized it would run the Start function where it assigns the player Object;
    private GameObject player;
    [SerializeField] private float MovementSpeed;
    [Header ("Public Attributes")]
    [SerializeField] private float distanceBetween;
    [SerializeField] private float distanceWonder;
    private float distance;

    void Start(){
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Tracking the player distance against THIS distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        // Approach if the distance is less than what is needed
        if(distance < distanceBetween){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, MovementSpeed*Time.deltaTime);
        }
    }
}
