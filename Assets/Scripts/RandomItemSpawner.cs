using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{

    public List<item> Items = new List<item>();    
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
    GameObject Timer(){
        //Spawn Random Object
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        int random = Random.Range(0, Items.Count);
        GameObject item = Items[Random.Range(0, Items.Count)].preFab;
        Instantiate(item, randomPos, Quaternion.identity);
        //Reset Time
        targetTime = orgTime;

        return item;
    }
}
[System.Serializable]
public class item{
    public GameObject preFab;
}
