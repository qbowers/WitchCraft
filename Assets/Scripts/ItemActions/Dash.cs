using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ItemAction {
    public float dashSpeed;
    private float direction;
    private Rigidbody2D rb;
    
    public void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public override void perform(){
        if (controller.m_FacingRight){
            direction = 1f;
        }
        else {
            direction = -1f;
        }
        rb.AddForce(new Vector2(dashSpeed * direction,0f));
    }
}
