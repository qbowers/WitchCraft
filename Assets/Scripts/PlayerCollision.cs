using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    // Start is called before the first frame update

    public ParticleSystem ps;
    void Start() {
        var emissionModule = ps.emission;
        emissionModule.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Monster")) {
            Debug.Log("you died");
        }
    }
}
