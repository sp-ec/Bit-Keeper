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

    public void SpawnBug(GameObject bug, int id){
        if (onSpawnBug != null){
            onSpawnBug(bug, id);
        }
    }

    public event Action<int> onUpgradePlayer;

    public void UpgradePlayer(int id){
        if (onUpgradePlayer != null){
            onUpgradePlayer(id);
        }
    }

    public event Action<int> onUpgradeCannon;

    public void UpgradeCannon(int id){
        if (onUpgradeCannon != null){
            onUpgradeCannon(id);
        }
    }
}
