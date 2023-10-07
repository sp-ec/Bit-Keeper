using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{

    protected override void RunCollision(RaycastHit2D hit){
        if (hit.collider.CompareTag("Bug")){
            return;
        } else if (hit.collider.CompareTag("Player")){
            Player playerScript = hit.transform.gameObject.GetComponent<Player>();
            playerScript.Damage(1);
        } else if (hit.collider.CompareTag("CPU")){
            CPU cpuScript = hit.transform.gameObject.GetComponent<CPU>();
            cpuScript.Damage(1);
        }
        base.RunCollision(hit);
    }
    
}
