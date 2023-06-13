using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectRoomSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct RandomSpawner 
    {
        public string name;
        public SpawnerData spawnerData;
    }

    public GridController grid;
    public RandomSpawner[] spawners;

     void Start()
    {
        grid = GetComponentInChildren<GridController>();
    }

    void SpawnObjects(RandomSpawner data)
    {
        int randomIteration = UnityEngine.Random.Range(data.spawnerData.minSpawn, data.spawnerData.maxSpawn + 1);

        for (int i = 0; i < randomIteration; i++)
        {
            int randomPos = UnityEngine.Random.Range(0, grid.availablePoints.Count - 1);
            GameObject go = Instantiate(data.spawnerData.itemToSpawn, grid.availablePoints[randomPos], Quaternion.identity, transform) as GameObject;
            grid.availablePoints.RemoveAt(randomPos);

          //  Debug.Log("Spawned Object");
            
        }
    }

    public void InitialiseObjectSpawning()
    {
        foreach (RandomSpawner randomSpawner in spawners)
        {
            SpawnObjects(randomSpawner);
        }
    }
}
