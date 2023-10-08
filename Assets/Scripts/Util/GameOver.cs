using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Button startOver;
    public Button mainMenu;

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
        mainMenu.onClick.AddListener(LoadMainMenu);
        startOver.onClick.AddListener(StartOver);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            gameOverScreen.SetActive(true);
            light.pointLightInnerRadius = 0.42f;
            light.pointLightOuterRadius = 1.26f;
            playerSR.sprite = deadBall;
            Time.timeScale = 0;
            HealthBar.healthBarObject.SetActive(false);
            pointsObject.SetActive(false);
            pointsText.text = "Points: " + Player.points;
        }
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Scenes/TitleScene");
    }

    public void StartOver() {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

}
