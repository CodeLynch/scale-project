using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyScript : MonoBehaviour
{
    private float activeTime = 5f;

    // Update is called once per frame
    void Update()
    {
        if(activeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            activeTime -= Time.deltaTime;;
        }
    }
}
