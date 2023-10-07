using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float inputX;
    private float inputY;
    [SerializeField] private float speed;
    private float currentSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;
    private Vector3 mousePos;
    [SerializeField] private GameObject cannon;

    SpriteRenderer sr;
    public HealthBar healthBar;
    [SerializeField] float maxHealth = 100;

    int points = 0;
    public TMP_Text pointsText;

    [Header("Power Levels")]
    private int speedLevel = 0;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        healthBar.health = maxHealth;

    }

    void Start() {

        pointsText.text = "Points: " + points.ToString();
        currentSpeed = speed;
        EventManager.current.onUpgradePlayer += UpgradePlayer;

        EventManager.current.UpgradeCannon(1);
        EventManager.current.UpgradeCannon(1);

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    
        Vector2 mouseDirection = CursorManager.current.GetMouseDirection(this.gameObject);

        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg + 90;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        cannon.transform.rotation = Quaternion.RotateTowards(cannon.transform.rotation, targetRotation, 100);

        tempTime += Time.deltaTime;
    }

    void FixedUpdate()
    {
        Move();
    }

    void GetInput(){
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        if (inputX != 0){
            inputX = Mathf.Sign(inputX);
        }
        if (inputY != 0){
            inputY = Mathf.Sign(inputY);
        }
        mousePos = Input.mousePosition;
    }

    void Move(){

        //horizontal
        float targetSpeed = inputX * currentSpeed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, 1) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.right);

        //vertical
        targetSpeed = inputY * currentSpeed;
        speedDif = targetSpeed - rb.velocity.y;
        accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, 1) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.up);


    }

    IEnumerator FlashRed() {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return null;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Bug")) {
            StartCoroutine(FlashRed());
            healthBar.damaged(1);
        }
    }

    float tempTime = 0;

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.CompareTag("Bug")) {
            if (tempTime > 2f) {
                healthBar.damaged(1);
                StartCoroutine(FlashRed());
                tempTime = 0;
            }
        }
    }

    public void addPoints(int pointsToAdd) {
        points += pointsToAdd;
        pointsText.text = "Points: " + points.ToString();
    }

    public void Damage(int amount){
        if (tempTime > 2f) {
            healthBar.damaged(1);
            StartCoroutine(FlashRed());
            tempTime = 0;
        }
    }

    void UpgradePlayer(int id){
        switch (id){
            case 0:
                speedLevel++;
                break;
        }
        UpdateStats();
    }

    void UpdateStats(){
        if (speedLevel != 0){
            currentSpeed = speed * (Mathf.Pow(1.3f, speedLevel));
        }
        
    }

}
