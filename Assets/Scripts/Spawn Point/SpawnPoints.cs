using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private int id;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.onSpawnBug += SpawnBug;
    }

    void SpawnBug(GameObject bug, int id){

        if (this.id == id){
            Instantiate(bug, transform.position, Quaternion.identity);
        }

    }

    
}
