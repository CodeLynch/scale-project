using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemieSpwner : MonoBehaviour
{

<<<<<<< HEAD
    public List<GameObject> enemy = new List<GameObject>();
    [SerializeField] private Transform upperLeftBound;
    [SerializeField] private Transform lowerRightBound;
    [SerializeField] private float targetTime = 60.0f;
    private float orgTime;
=======
    public List<GameObject> enemies = new List<GameObject>();
>>>>>>> cceefc7fdb6513d92633fbd8a777e9d543794055

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
            GenerateTimer();
        }
    }
<<<<<<< HEAD
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
=======
    void GenerateTimer(){
        GenerateEnemies();
        randomTime = Random.Range(0, maxTime);
    }
    public void GenerateEnemies(){
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        int random = Random.Range(0, enemies.Count);
        Instantiate(enemies[random], randomPos, Quaternion.identity);
>>>>>>> cceefc7fdb6513d92633fbd8a777e9d543794055
    }
}