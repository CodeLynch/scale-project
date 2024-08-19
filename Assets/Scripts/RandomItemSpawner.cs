using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{

    public List<Item> Items = new List<Item>();
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
        int random = Random.Range(0, Items.Count);
        GameObject item = Items[Random.Range(0, Items.Count)].ItemPrefab;
        Instantiate(item, randomPos, Quaternion.identity);
        //Reset Time
        targetTime = orgTime;
        //Reducing Limit??
        this.Limit--;

        return item;
    }
}
[System.Serializable]
public class Item{
    public GameObject ItemPrefab;
    public int rate; 
}