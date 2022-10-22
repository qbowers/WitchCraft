using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : PotionExplosion
{
    public float knockbackForce; 
    public float monsterMult;
    private float knockbackMult;

    public override void affect(GameObject obj){
        if (obj.CompareTag("Monster")){
            knockbackMult = knockbackForce * monsterMult;
        }
        else{
            knockbackMult = knockbackForce;
        }
        Vector3 dir = (obj.transform.position - transform.position).normalized;
        obj.GetComponent<Rigidbody2D>().AddForce(knockbackMult * dir, ForceMode2D.Impulse);
    }
}
