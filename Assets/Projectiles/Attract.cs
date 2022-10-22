using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : PotionExplosion
{
    public float attractForce; 

    public override void affect(GameObject obj){
        Vector3 dir = -(obj.transform.position - transform.position).normalized;
        obj.GetComponent<Rigidbody2D>().AddForce(attractForce * dir);
    }
}
