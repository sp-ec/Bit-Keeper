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

        /*
        numWaves++;
        if (numWaves < 3){
            waveScript.numNormalBugs = numWaves * 10;
            waveScript.numChaserBugs = 0;
            waveScript.numSpitterBugs = 0;
        } else if (numWaves < 6) {
            
        } else if (numWaves < 10) {
           
        } else {
            
        }
        */
        waveScript.numNormalBugs = 20;
        waveScript.numChaserBugs = 0;
        waveScript.numSpitterBugs = 0;

        SpawnWave();

        Debug.Log(waveScript.numNormalBugs);
    }

    private void SpawnWave(){

        int currentId = 0;

        for (int i = 0; i < waveScript.numNormalBugs; i++){
            currentId++;
            if (currentId > 3){
                currentId = 0;
            }
            StartCoroutine(DelayedSpawn(bugObject, 0.2f * i, currentId));
        }
        for (int i = 0; i < waveScript.numChaserBugs; i++){
            currentId++;
            if (currentId > 3){
                currentId = 0;
            }
            StartCoroutine(DelayedSpawn(chaserBugObject, 3f * i, currentId));
        }
        for (int i = 0; i < waveScript.numSpitterBugs; i++){
            currentId++;
            if (currentId > 3){
                currentId = 0;
            }
            StartCoroutine(DelayedSpawn(spitterBugObject, 2f * i, currentId));
        }
    }

    IEnumerator DelayedSpawn(GameObject bug, float delay, int id) {
        yield return new WaitForSeconds(delay);
        EventManager.current.SpawnBug(bug, id);
        
    }
}
