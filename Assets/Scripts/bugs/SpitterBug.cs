using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class SpitterBug : AbstractBug
{
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private float fireCooldown;
    [SerializeField] private float bulletSpeed;
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

        float distance = Vector3.Distance (transform.position, cpuPosition);

        if (fireCooldownCounter <= 0 && distance <= 5){
            Shoot();
        }

    }

    void Shoot() {

        fireCooldownCounter = fireCooldown;

        GameObject bullet = Instantiate(bulletObject, transform.position, Quaternion.identity);
        
        EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();

        Vector2 worldPosition = GameObject.FindGameObjectWithTag("CPU").GetComponent<Transform>().position;
        Vector2 direction = new Vector2(
            worldPosition.x - transform.position.x,
            worldPosition.y - transform.position.y
        ).normalized;

        bulletScript.Create(direction, bulletSpeed);
    }

}
