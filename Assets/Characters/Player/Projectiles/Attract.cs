using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : PotionExplosion
{
    public float attractForce;
    public float monsterMult;
    private float attractMult;
    public float jumpThreshold;
    private new Rigidbody2D rigidbody;

    public override void affect(GameObject obj){
        if (obj.CompareTag("Monster")){
            attractMult = attractForce * monsterMult;
        }
        else{
            attractMult = attractForce;
        }
        Vector3 diffVector = -(obj.transform.position - transform.position);
        if (diffVector.magnitude > 3f){
            attractMult *= 1f / diffVector.magnitude;
            Vector3 dir = diffVector.normalized;
            obj.GetComponent<Rigidbody2D>().AddForce(attractMult * dir, ForceMode2D.Impulse);
        }
    }
}
