using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class BossBug : AbstractBug
{
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private float fireCooldown;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private int numBullets;
    private float fireCooldownCounter;
    private Vector2 cpuPosition;
    protected override void Start(){
        base.Start();
        cpuPosition = GameObject.FindGameObjectWithTag("CPU").GetComponent<Transform>().position;
        GetComponent<AIPath>().destination = cpuPosition;
    }

    void Update()
    {
        fireCooldownCounter -= Time.deltaTime;

        if (fireCooldownCounter <= 0){
            Shoot();
        }

    }

    void Shoot() {

        fireCooldownCounter = fireCooldown;

        Vector2 worldPosition = player.transform.position;
        Vector2 direction = new Vector2(
            worldPosition.x - transform.position.x,
            worldPosition.y - transform.position.y
        ).normalized;

        for (int i = 0; i < numBullets; i++){
                    float tempSpread = (-90/2) + (i * (90/(numBullets-1)));
                    Vector2 spreadDirection = Quaternion.Euler(0, 0, tempSpread) * direction;

                    GameObject bullet = Instantiate(bulletObject, exitPoint.position, Quaternion.identity);
                    EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
                    bulletScript.Create(spreadDirection, bulletSpeed);
                    
                }
    }



}
