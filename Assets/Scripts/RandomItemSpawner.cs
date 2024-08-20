using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{

    public List<GameObject> Items = new List<GameObject>();    
    [SerializeField] private float Radius = 1.0f;
    [SerializeField] private float targetTime = 60.0f;
    private float orgTime;

    void Start(){
        orgTime = targetTime;
    }
    void FixedUpdate()
    {
        targetTime -= Time.deltaTime;
        if(targetTime <= 0){
            Debug.Log("Something");
            Timer();
        }
    }
    void Timer(){
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        Instantiate(Items[Random.Range(0, Items.Count)], randomPos, Quaternion.identity);
        targetTime += orgTime;
    }
}