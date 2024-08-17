using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpwner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn= new List<GameObject>();
    public Transform[] spawnLocation;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        
    }

    public void GenerateEnemies(){
        
    }
}

public class Enemy
{
    public GameObject enemyPrefab;
    public int SpawnRate; //The rate of spawnable enemy
}