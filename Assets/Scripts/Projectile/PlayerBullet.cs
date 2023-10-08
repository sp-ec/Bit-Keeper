using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Projectile
{

    protected override void RunCollision(RaycastHit2D hit){
        if (hit.collider.CompareTag("Bug")){
            AbstractBug bugScript = hit.transform.gameObject.GetComponent<AbstractBug>();
            bugScript.damageEnemy();
        } else if (hit.collider.CompareTag("Player")){
            return;
        }
        base.RunCollision(hit);
    }
    
}
