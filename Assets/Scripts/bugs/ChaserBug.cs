using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class ChaserBug : AbstractBug
{
    void FixedUpdate(){
        GetComponent<AIPath>().destination = player.transform.position;
    }

}
