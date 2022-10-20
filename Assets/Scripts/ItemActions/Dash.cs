using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ItemAction {
    public float dashSpeed;

    public override void perform(){
        controller.ApplyForce(new Vector2(dashSpeed * controller.transform.localScale.x, 0f));
        // StartCoroutine(dash(3));
    }

    // IEnumerator dash(float delayTime)
    // {
    //     float oldSpeed = movement.maxSpeed;
    //     movement.maxSpeed = dashSpeed;
    //     movement.directionX = 1;
    //     //Wait for the specified delay time before continuing.
    //     yield return new WaitForSeconds(delayTime);
        
    //     //Do the action after the delay time has finished.
    //     movement.maxSpeed = oldSpeed;
    // }
}
