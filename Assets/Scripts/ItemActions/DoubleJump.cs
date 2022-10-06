using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : ItemAction {
    public float jumpForce;
    public override void perform(){
        controller.ApplyForce(new Vector2(0f,jumpForce));
    }
}