using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLevel : MonoBehaviour {
    public string level;
    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name != "Player") {
            return;
        }

        CoreManager.instance.LoadLevel(level);
    }
}
