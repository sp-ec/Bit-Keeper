using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float smoothing;

     private void FixedUpdate(){
        if (transform.position != target.transform.position){

            Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            
        }
    }
}
