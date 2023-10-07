using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class AbstractBug : MonoBehaviour
{

    SpriteRenderer sr;
    Rigidbody2D rb;
    
    [SerializeField] int maxHealth = 1;
    int health;

    public int points = 1;

    public Player player;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    protected virtual void Start() {
        health = maxHealth;
        sr.color = Color.white;
        
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
