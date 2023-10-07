using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    SpriteRenderer sr;
    Rigidbody2D rb;
    [SerializeField] Transform target;
    Vector2 moveDirection;
    [SerializeField] GameObject bullet;

    [SerializeField] int maxHealth = 1;
    int health;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        health = maxHealth;
        sr.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        moveDirection = direction;

    }

    void FixedUpdate() {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == bullet.tag) {
            health -= 1;
            if (health == 0) {
                sr.color = Color.red;
                Destroy(gameObject, 0.5f);
            }
        }
    }

}
