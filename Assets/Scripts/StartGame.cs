using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    Button startButton;
    public Button exitButton;


    void Awake() {
        startButton = GetComponent<Button>();
    }
    void Start()
    {
        startButton.onClick.AddListener(StartGameButton);
        exitButton.onClick.AddListener(ExitGameButton);
    }

    public void StartGameButton() {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void ExitGameButton() {
        Application.Quit();
    }

}
