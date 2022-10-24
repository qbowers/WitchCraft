using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    // Start is called before the first frame update

    ParticleSystem ps;
    void Start() {
        ps = GetComponent<ParticleSystem>();
        var emissionModule = ps.emission;
        emissionModule.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Monster")) {
            var emissionModule = ps.emission;

            emissionModule.enabled = true;
            StartCoroutine(StopParticle());
            
            Debug.Log("you died");
        }
    }

    IEnumerator StopParticle() {
        yield return new WaitForSeconds(3f);

        ps.Stop();
    }
}
