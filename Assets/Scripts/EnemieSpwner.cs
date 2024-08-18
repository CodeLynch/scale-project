using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemieSpwner : MonoBehaviour
{

    public List<GameObject> enemies = new List<GameObject>();

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
    void GenerateTimer(){
        GenerateEnemies();
        randomTime = Random.Range(0, maxTime);
    }
    public void GenerateEnemies(){
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        int random = Random.Range(0, enemies.Count);
        Instantiate(enemies[random], randomPos, Quaternion.identity);
    }
}