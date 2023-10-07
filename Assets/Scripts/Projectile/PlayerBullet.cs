using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Projectile
{
    protected override void RunCollision(RaycastHit2D hit){
        if (hit.collider.CompareTag("Bug")){
            Bug bugScript = hit.transform.gameObject.GetComponent<Bug>();
            bugScript.damageEnemy();
        }
        base.RunCollision(hit);
    }
}
