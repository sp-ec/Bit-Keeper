using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager current;
    int numWaves = 1;
    Wave currentWave;
    [SerializeField] private ArrayList spawnPoints;
    
    void Awake()
    {
       current = this; 
    }

    void Start(){
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWave(){
        if (numWaves < 3){
            currentWave = new Wave(numWaves * 10, 0, 0);
        } else if (numWaves < 6) {
            currentWave = new Wave(numWaves * 8, numWaves, 0);
        } else if (numWaves < 10) {
            currentWave = new Wave(numWaves * 8, numWaves * 2, numWaves);
        } else {
            currentWave = new Wave(numWaves * 6, numWaves * 3, numWaves * 2);
        }
    }

    private void SpawnWave(){

    }
}
