using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.onSpawnBug += SpawnBug;
    }

    void SpawnBug(GameObject bug, int amount){
        Debug.Log("Spawning Bug");
        for (int i = 0; i < amount; i++){
            Instantiate(bug, transform.position, Quaternion.identity);
        }
    }
}
