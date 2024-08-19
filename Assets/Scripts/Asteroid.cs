using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{  
    [SerializeField] private float Speed = 1;
    [SerializeField] private float distanceWonder;
    [SerializeField] private float range;
    private Vector2 wonder;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, wonder, Speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, wonder) < range){
                wonder = new Vector2(Random.Range(-distanceWonder, distanceWonder), Random.Range(-distanceWonder, distanceWonder));
            }
    }
}
