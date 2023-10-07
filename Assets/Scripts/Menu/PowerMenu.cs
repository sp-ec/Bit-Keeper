using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMenu : MonoBehaviour
{

    public bool enablePowerMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        enablePowerMenu = false;   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space")) {
            enablePowerMenu = !enablePowerMenu;
        }

        if (enablePowerMenu) {

            Time.timeScale = 0;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

        } else {
            Time.timeScale = 1;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}