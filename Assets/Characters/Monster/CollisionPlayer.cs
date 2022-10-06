using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    void onCollisionEnter(Collision2D collision) {

        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.gameObject.tag);
        Debug.Log("collision");

        // Check if it collides with player
        if (collision.gameObject.name == "Player") {
            Debug.Log("you died");
        }
    }
}
