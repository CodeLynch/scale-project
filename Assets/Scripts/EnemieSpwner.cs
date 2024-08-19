using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{

    public List<Item> enemy = new List<Item>();
    [SerializeField] private float Radius = 1.0f;
    [SerializeField] private float targetTime = 60.0f;
    [SerializeField] private float Limit = 10;
    private float orgTime;

    void Start(){
        orgTime = targetTime;
    }
    void FixedUpdate()
    {
        targetTime -= Time.deltaTime;
        if(targetTime <= 0 && Limit > 0){
            Timer();
        }
    }
    GameObject Timer(){
        //Spawn Random Object
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        GameObject Enemy = enemy[Selector()].ItemPrefab;
        Instantiate(Enemy, randomPos, Quaternion.identity);
        //Reset Time
        targetTime = orgTime;
        //Reducing Limit??
        this.Limit--;

        return Enemy;
    }

    private int Selector(){
        int rnd = Random.Range(0,10);
        if(rnd >= 0 && rnd < 7){
            return 1;
        } else if(rnd >= 7 && rnd < 10){
            return 2;
        } else {
            return 3;
        }
    }
}