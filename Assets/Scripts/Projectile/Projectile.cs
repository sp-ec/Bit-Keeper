using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    [SerializeField] protected Vector2 direction;
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D rb;
    Vector2 previousPosition;

    void Update(){
        RunRaycast();
    }

    protected virtual void LateUpdate(){
        previousPosition = transform.position;
    }

    public void Create(Vector2 direction, float speed){
        this.direction = direction;
        this.speed = speed;
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    private void RunRaycast(){

    }

    private void RunCollision(){

    }


}
