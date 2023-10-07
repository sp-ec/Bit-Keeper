using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    [SerializeField] Transform target;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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

}
