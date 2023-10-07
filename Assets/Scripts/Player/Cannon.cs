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

    // Start is called before the first frame update
    void Start()
    {
        
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
}
