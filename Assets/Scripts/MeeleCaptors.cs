using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private float range;
    private float distance;
    private Vector2 wonder;
    void Start(){
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Tracking the player distance against THIS distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        // Approach if the distance is less than what is needed
        if(distance < distanceBetween){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, MovementSpeed*Time.deltaTime);
        } else {
            transform.position = Vector2.MoveTowards(this.transform.position, wonder, MovementSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, wonder) < range){
                wonder = new Vector2(Random.Range(-distanceWonder, distanceWonder), Random.Range(-distanceWonder, distanceWonder));
            }
        }
    }
}
