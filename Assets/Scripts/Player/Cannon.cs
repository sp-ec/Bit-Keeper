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
    float numBullets;

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

        fireCooldownCounter = fireCooldown;
        GameObject bullet = Instantiate(bulletObject, exitPoint.position, Quaternion.identity, runtimeObject);
        PlayerBullet bulletScript = bullet.GetComponent<PlayerBullet>();
        bulletScript.Create(CursorManager.current.GetMouseDirection(this.gameObject), bulletSpeed);
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
