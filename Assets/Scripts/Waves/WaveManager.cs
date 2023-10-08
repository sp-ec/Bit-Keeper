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
    [SerializeField] private GameObject bossBugObject;
    private int numNormalBugs;
    private int numChaserBugs;
    private int numSpitterBugs;
    private int numBossBugs;
    
    void Awake()
    {
       current = this; 
       waveScript = GetComponent<Wave>();
    }

    void Start(){
        NextWave();
        StartCoroutine(CheckWaveStatus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWave(){
        
        numWaves++;
        if (numWaves == 1){
            numNormalBugs = numWaves * 10;
            numChaserBugs = 0;
            numSpitterBugs = 0;
            numBossBugs = 0;
        } else if (numWaves == 2) {
            numNormalBugs = 0;
            numChaserBugs = 4;
        } else if (numWaves == 3) {
            numNormalBugs = 0;
            numChaserBugs = 0;
            numSpitterBugs = 4;
        } else if (numWaves == 4){
            numNormalBugs = 20;
            numChaserBugs = 4;
            numSpitterBugs = 4;
        } else if (numWaves == 5){
            numNormalBugs = 20;
            numChaserBugs = 0;
            numSpitterBugs = 0;
            numBossBugs = 1;
        } else {
            numNormalBugs = numWaves * 8;
            numChaserBugs = numWaves;
            numSpitterBugs = numWaves * 2;
            if (numWaves%5 == 0){
                numBossBugs = (numWaves - 10)/5;
            } else {
                numBossBugs = 0;
            }
        }
    
        SpawnWave();

        Debug.Log(numNormalBugs);
    }

    private void SpawnWave(){

        int currentId = 0;

        for (int i = 0; i < numNormalBugs; i++){
            currentId++;
            if (currentId > 3){
                currentId = 0;
            }
            StartCoroutine(DelayedSpawn(bugObject, 0.5f * i, currentId));
        }
        for (int i = 0; i < numChaserBugs; i++){
            currentId++;
            if (currentId > 3){
                currentId = 0;
            }
            StartCoroutine(DelayedSpawn(chaserBugObject, 3f * i, currentId));
        }
        for (int i = 0; i < numSpitterBugs; i++){
            currentId++;
            if (currentId > 3){
                currentId = 0;
            }
            StartCoroutine(DelayedSpawn(spitterBugObject, 2f * i, currentId));
        }
        for (int i = 0; i < numBossBugs; i++){
            currentId++;
            if (currentId > 3){
                currentId = 0;
            }
            StartCoroutine(DelayedSpawn(bossBugObject, 7f * i, currentId));
        }
    }

    IEnumerator DelayedSpawn(GameObject bug, float delay, int id) {
        yield return new WaitForSeconds(delay);
        EventManager.current.SpawnBug(bug, id);
        
    }

    IEnumerator CheckWaveStatus(){
        while (true){
            yield return new WaitForSeconds(1);
            if (GameObject.FindGameObjectWithTag("Bug") == null){
                PowerMenu.enablePowerMenu = true;
                NextWave();
            } else {
                Debug.Log("Bug Found: " + GameObject.FindGameObjectWithTag("Bug"));
            }
        }
    }
}
