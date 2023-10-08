using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMenu : MonoBehaviour
{

    public static bool enablePowerMenu = false;

    public static GameObject pm;

    // Start is called before the first frame update
    void Awake()
    {
        enablePowerMenu = false;   
        pm = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (enablePowerMenu) {

            Time.timeScale = 0;
            pm.transform.GetChild(0).gameObject.SetActive(true);

        } else {
            if (!GameOver.gameOver)
                Time.timeScale = 1;
            pm.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}