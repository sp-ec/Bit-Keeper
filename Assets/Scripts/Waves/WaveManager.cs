using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager current;
    int numWaves = 0;
    private Wave waveScript;
    [SerializeField] private GameObject bugObject;
    [SerializeField] private GameObject chaserBugObject;
    [SerializeField] private GameObject spitterBugObject;
    
    void Awake()
    {
       current = this; 
       waveScript = GetComponent<Wave>();
    }

    void Start(){
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWave(){

        //num bugs is per spawn point, not in total;

        numWaves++;
        if (numWaves < 3){
            waveScript.numNormalBugs = numWaves * 5;
            waveScript.numChaserBugs = 0;
            waveScript.numSpitterBugs = 0;
        } else if (numWaves < 6) {
            
        } else if (numWaves < 10) {
           
        } else {
            
        }
        SpawnWave();
    }

    private void SpawnWave(){
        EventManager.current.SpawnBug(bugObject, waveScript.numNormalBugs);
        EventManager.current.SpawnBug(chaserBugObject, waveScript.numChaserBugs);
        EventManager.current.SpawnBug(spitterBugObject, waveScript.numSpitterBugs);
    }
}
