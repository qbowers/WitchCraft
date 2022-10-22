using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : PotionExplosion
{
    public float knockbackForce; 

    public override void affect(GameObject obj){
        Vector3 dir = (obj.transform.position - transform.position).normalized;
        obj.GetComponent<Rigidbody2D>().AddForce(knockbackForce * dir);
    }
}
