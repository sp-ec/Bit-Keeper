using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    public static bool gameOver = false;
    public UnityEngine.Rendering.Universal.Light2D light;
    SpriteRenderer playerSR;
    public Sprite ball;
    public Sprite deadBall;
    public GameObject pointsObject;
    public TMP_Text pointsText;
    public GameObject gameOverScreen;

    void Awake() {
        playerSR = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        pointsObject.SetActive(true);
    }
    void Start()
    {
        gameOverScreen.SetActive(false);
        gameOver = false;
        light.pointLightInnerRadius = 7.42f;
        light.pointLightOuterRadius = 18.1f;
        playerSR.sprite = ball;
        HealthBar.healthBarObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            gameOverScreen.SetActive(true);
            gameOver = true;
            light.pointLightInnerRadius = 0.42f;
            light.pointLightOuterRadius = 1.26f;
            playerSR.sprite = deadBall;
            Time.timeScale = 0;
            HealthBar.healthBarObject.SetActive(false);
            pointsObject.SetActive(false);
            pointsText.text = "Points: " + Player.points;
        }
    }
}
