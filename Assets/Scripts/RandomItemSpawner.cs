using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{


    public List<GameObject> Items = new List<GameObject>();
    [SerializeField] private float targetTime = 60.0f;
    [SerializeField] private Transform upperLeftBound;
    [SerializeField] private Transform lowerRightBound;


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
            Random.Range(lowerRightBound.position.y,upperLeftBound.position.y));
        int random = Random.Range(0, Items.Count);
        GameObject item = Items[Random.Range(0, Items.Count)];
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
