using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : ItemAction {
    public float jumpHeight;
    public override string keybind { get{ return "Action2"; } }

    public override void perform(){
        controller.ApplyForce(new Vector2(0f, jumpHeight));
    }
}