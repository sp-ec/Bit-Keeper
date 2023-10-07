using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{

    public HealthBar healthBar;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;
    }


    IEnumerator FlashRed()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    float tempTime = 0;
    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.CompareTag("Bug")) {
            Damage(1);
        }
    }

    public void Damage(int amount){
        if (tempTime > 2f) {
            healthBar.damaged(amount);
            StartCoroutine(FlashRed());
            tempTime = 0;
        }
    }


}
