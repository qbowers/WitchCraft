using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : PotionExplosion {
    public float knockbackForce; 
    public float monsterMult;
    private new Rigidbody2D rigidbody;

    public override void affect(GameObject obj){
        float force = knockbackForce * (obj.CompareTag("Monster") ? monsterMult : 1);
        
        // clamp to 8 directions
        Vector3 dir = DirectionClamp8((obj.transform.position - transform.position).normalized);
        rigidbody = obj.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
        rigidbody.AddForce(force * dir, ForceMode2D.Impulse);
    }

    Vector3 DirectionClamp8(Vector3 vector) {
        // compares only the x,y coords to clamp to 8 directions
        float z = vector[2];
        // In radians
        float angle = Mathf.Atan2(vector[1], vector[0]) + Mathf.PI/8;
        float scale = 8f/(2*Mathf.PI);
        angle = ((int) (scale*angle)) / scale;
        return new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), z);
        // return vector;
    }
}
