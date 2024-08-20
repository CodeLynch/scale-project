using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemieSpwner : MonoBehaviour
{


    public List<GameObject> enemy = new List<GameObject>();
    [SerializeField] private Transform upperLeftBound;
    [SerializeField] private Transform lowerRightBound;
    [SerializeField] private float targetTime = 60.0f;
    private float orgTime;


    [SerializeField] private float Radius = 10;
    [SerializeField] private float maxTime = 10;
    
    
    private float randomTime = 0;

    void Start()
    {
        randomTime = Random.Range(0, maxTime);
    }
    void FixedUpdate()
    {
        if(randomTime <= 0){
            randomTime = Random.Range(0, maxTime);
        }
        randomTime -= Time.deltaTime;
        if(randomTime <= 0.0f){
            Timer();
        }
    }

    GameObject Timer(){
        //Spawn Random Object
        Vector2 randomPos = new Vector2(Random.Range(upperLeftBound.position.x, lowerRightBound.position.x), 
            Random.Range(lowerRightBound.position.y, upperLeftBound.position.y));
        GameObject Enemy = enemy[Selector()];
        Instantiate(Enemy, randomPos, Quaternion.identity);
        //Reset Time
        targetTime = orgTime;

        return Enemy;
    }

    private int Selector() {
        int rnd = Random.Range(0, 10);
        if (rnd >= 0 && rnd < 6) {
            return 0;
        } else if (rnd >= 6 && rnd < 7) {
            return 1;
        } else {
            return 2;
        }
    }
}