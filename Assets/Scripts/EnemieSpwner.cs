using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{

    public List<GameObject> enemy = new List<GameObject>();
    [SerializeField] private Transform upperLeftBound;
    [SerializeField] private Transform lowerRightBound;
    [SerializeField] private float targetTime = 60.0f;
    private float orgTime;

    void Start(){
        orgTime = targetTime;
    }
    void FixedUpdate()
    {
        targetTime -= Time.deltaTime;
        if(targetTime <= 0){
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

    private int Selector(){
        int rnd = Random.Range(0,10);
        if(rnd >= 0 && rnd < 6){
            return 0;
        } else if(rnd >= 6 && rnd < 7){
            return 1;
        } else {
            return 2;
        }
    }
}