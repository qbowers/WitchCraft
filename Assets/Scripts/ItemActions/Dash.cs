using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ItemAction {
    public float dashSpeed;

    public override void perform(){
        controller.ApplyForce(new Vector2(dashSpeed, 0f));
    }
}
