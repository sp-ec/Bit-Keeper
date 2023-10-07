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

    protected override void Start(){
        base.Start();
        GetComponent<AIPath>().destination = GameObject.FindGameObjectWithTag("CPU").GetComponent<Transform>().position;
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
