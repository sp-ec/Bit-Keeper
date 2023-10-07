using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    [SerializeField] protected Vector2 direction;
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
