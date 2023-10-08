using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class BossBug : AbstractBug
{
    [SerializeField] private GameObject bugObject;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private Transform spawnPoint;
    private float spawnCooldownCounter;
    private Vector2 cpuPosition;
    protected override void Start(){
        base.Start();
        cpuPosition = GameObject.FindGameObjectWithTag("CPU").GetComponent<Transform>().position;
        GetComponent<AIPath>().destination = cpuPosition;
    }

    void Update()
    {
        spawnCooldownCounter -= Time.deltaTime;

        if (spawnCooldownCounter <= 0){
            Spawn();
        }

    }

    void Spawn() {

        spawnCooldownCounter = spawnCooldown;
        Instantiate(bugObject, spawnPoint.position, Quaternion.identity);
    }



}
