using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionExplosion : MonoBehaviour
{
    public float explosionRadius;
    public float explosionDuration;

    void Start(){
        StartCoroutine(disappearAfterDuration());
    }

    void FixedUpdate(){
        var colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach(Collider2D collider in colliders) {
            // Debug.Log($"{collider.gameObject.name} is nearby");
            if (collider.CompareTag("Player") || collider.CompareTag("Monster") ){
                Debug.Log("affecting " + collider.gameObject.name);
                affect(collider.gameObject);
            }
        }
    }

    IEnumerator disappearAfterDuration(){
        yield return new WaitForSeconds(explosionDuration);
        Destroy(gameObject);
    }

    public abstract void affect(GameObject obj);
}
