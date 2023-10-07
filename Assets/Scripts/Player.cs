using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float inputX;
    private float inputY;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
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
    }

    void Move(){

        //horizontal
        float targetSpeed = inputX * speed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, 1) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.right);

        //vertical
        targetSpeed = inputY * speed;
        speedDif = targetSpeed - rb.velocity.y;
        accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, 1) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.up);


    }
}
