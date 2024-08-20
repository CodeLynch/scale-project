using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField] private float Speed = 100f;
    private GameObject player;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += player.transform.position * Speed * Time.deltaTime;
    }
}
