using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    int numNormalBugs;
    int numChaserBugs;
    int numSpitterBugs;
    public Wave(int numNormalBugs, int numChaserBugs, int numSpitterBugs){
        this.numNormalBugs = numNormalBugs;
        this.numChaserBugs = numChaserBugs;
        this.numSpitterBugs = numSpitterBugs;
    }
}
