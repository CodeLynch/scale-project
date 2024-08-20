using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{  
    [SerializeField] private float Speed = 1;
    [SerializeField] private float distanceWonder;
    [SerializeField] private float range;
    [SerializeField] private float power;
    [SerializeField] private float lifeTime;
    private Vector2 wonder;
    private Vector2 dir;
    private Rigidbody2D rb;
    private void Start()
    {
        float randomX = Random.Range(-power, power);
        float randomY = Random.Range(-power, power);
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(randomX, randomY);
        rb.AddForce(new Vector2(transform.position.x, transform.position.y) + dir, ForceMode2D.Impulse);
       
    }
    // Update is called once per frame
    void Update()
    {
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;

        }
        
        /*transform.position = Vector2.MoveTowards(this.transform.position, wonder, Speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, wonder) < range){
                wonder = new Vector2(Random.Range(-distanceWonder, distanceWonder), Random.Range(-distanceWonder, distanceWonder));
            }*/
    }
}
