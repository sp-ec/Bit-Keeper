using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    Button button;


    void Awake() {
        button = GetComponent<Button>();
    }
    void Start()
    {
        button.onClick.AddListener(StartGameButton);
    }

    public void StartGameButton() {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

}
