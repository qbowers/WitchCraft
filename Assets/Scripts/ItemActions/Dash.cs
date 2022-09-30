using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ItemAction
{
    public float dashSpeed;
    private float direction;
    public void start(){
        if (controller.m_FacingRight){
            direction = 1f;
        }
        else {
            direction = -1f;
        }
        controller.Move(dashSpeed * direction * Time.fixedDeltaTime, false, false);
    }
}
