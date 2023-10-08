using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Selection : MonoBehaviour {

    Button button;
    TMP_Text title;

    void Awake() {
        title = gameObject.transform.GetChild(2).GetChild(0).gameObject.GetComponent<TMP_Text>();
        button = gameObject.transform.GetChild(2).GetComponent<Button>();
    }

    void Start() {
        button.onClick.AddListener(Selected);
    }

    void Selected() {
        PowerMenu.enablePowerMenu = false;
        Debug.Log("FHAJDKFHJKDSA");
        if (title.text.Equals("Fire Rate")) {
            EventManager.current.UpgradeCannon(0);
        } else if (title.text.Equals("Multi-shot")) {
            EventManager.current.UpgradeCannon(1);
        } else if (title.text.Equals("Speed")) {
            EventManager.current.UpgradePlayer(0);
        }
    }
}