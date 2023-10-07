using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class SpitterBug : AbstractBug
{
    protected override void Start(){
        base.Start();
        GetComponent<AIPath>().destination = GameObject.FindGameObjectWithTag("CPU").GetComponent<Transform>().position;
    }

}
