using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{

    public List<Item> Items = new List<Item>();
    public List<GameObject> ItemsToSpawn = new List<GameObject>();    
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
    void Timer(){
        SpawnObjectRandom();
        targetTime = orgTime;
        Limit--;
    }
    void SpawnObjectRandom(){
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        int random = Random.Range(0, ItemsToSpawn.Count);
        Instantiate(ItemsToSpawn[random], randomPos, Quaternion.identity);
    }
    private void OnDrawnGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
[System.Serializable]
public class Item{
    public GameObject ItemPrefab;
    public int rate;    
}