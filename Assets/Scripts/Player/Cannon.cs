using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private float fireCooldown;
    private float fireCooldownCounter;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private Transform runtimeObject;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float multiBulletSpread;
    float numBullets = 1;

    [Header("Power Levels")]
    private int fireRateLevel = 0;
    private int numBulletsLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.onUpgradeCannon += UpgradeCannon;
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldownCounter -= Time.deltaTime;

        if (Input.GetButton("Fire1") && fireCooldownCounter <= 0){
            Shoot();
        }
    }

    void Shoot() {

        Vector2 direction = CursorManager.current.GetMouseDirection(this.gameObject);

        if (numBullets > 1){
                for (int i = 0; i < numBullets; i++){
                    float tempSpread = (-multiBulletSpread/2) + (i * (multiBulletSpread/(numBullets-1)));
                    Vector2 spreadDirection = Quaternion.Euler(0, 0, tempSpread) * direction;

                    GameObject bullet = Instantiate(bulletObject, exitPoint.position, Quaternion.identity);
                    PlayerBullet bulletScript = bullet.GetComponent<PlayerBullet>();
                    bulletScript.Create(spreadDirection, bulletSpeed);
                    
                }
            } else {
                GameObject bullet = Instantiate(bulletObject, exitPoint.position, Quaternion.identity);
                PlayerBullet bulletScript = bullet.GetComponent<PlayerBullet>();
                bulletScript.Create(direction, bulletSpeed);
        }

        fireCooldownCounter = fireCooldown;
    }

    void UpgradeCannon(int id){
        switch (id){
            case 0:
                fireRateLevel++;
                break;
            case 1:
                numBulletsLevel++;
                break;
        }
        UpdateStats();
    }

    void UpdateStats(){
        if (fireRateLevel != 0){
            fireCooldown = fireCooldown * (Mathf.Pow(0.8f, fireRateLevel));
        }
        numBullets = 1 + numBulletsLevel;
    }
}
