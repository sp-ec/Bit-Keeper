using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    [SerializeField] protected Vector2 direction;
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D rb;
    Vector2 previousPosition;
    string[] raycastLayers = {"Default", "Wall"};

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
        RaycastHit2D hit = Physics2D.Linecast(previousPosition, transform.position, LayerMask.GetMask(raycastLayers));
        if (hit.collider != null){
            RunCollision(hit);
        }
    }

    protected virtual void RunCollision(RaycastHit2D hit){
        Destroy(this.gameObject);
    }


}
