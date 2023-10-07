using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bug : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    
    [SerializeField] int maxHealth = 1;
    int health;

    public int points = 1;

    public Player player;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

    IEnumerator FlashRed() {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return null;
    }

    public void damageEnemy() {
        StartCoroutine(FlashRed());
        health -= 1;
        if (health == 0) {
            sr.color = Color.red;
            Destroy(gameObject, 0.1f);
            player.addPoints(points);
        }
    }

}
