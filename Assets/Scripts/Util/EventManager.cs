using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager current;
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }

    public event Action<GameObject, int> onSpawnBug;

    public void SpawnBug(GameObject bug, int amount){
        if (onSpawnBug != null){
            onSpawnBug(bug, amount);
        }
    }
}
