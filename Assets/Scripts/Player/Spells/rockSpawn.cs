using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class rockSpawn : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] whatToSpawnPrefab;

    private void Start()
    {
        InputManager.SpellEvent += spawnRock;
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        spawnRock();
    //    }
    //}

    void spawnRock(string[] s)
    {
        string[] localArray = s;
        if (localArray[0] == "i" && localArray[1] == "l" && localArray[2] == "j")
        {
             Instantiate(whatToSpawnPrefab[0], spawnLocations[0].transform.position, quaternion.Euler(0, 0, 0));
        }
         
    }
}
