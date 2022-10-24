using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionExplosion : MonoBehaviour {
    public bool continuous;
    public float explosionDuration;

    void Start(){
        StartCoroutine(disappearAfterDuration());
    }

    void FixedUpdate(){
        if (continuous) {
            List<Collider2D> colliders = new List<Collider2D>();
            ContactFilter2D filter = new ContactFilter2D().NoFilter();
            GetComponent<Collider2D>().OverlapCollider(filter, colliders);
            foreach(Collider2D collider in colliders) {
                // Debug.Log($"{collider.gameObject.name} is nearby");
                if (collider.CompareTag("Player") || collider.CompareTag("Monster") ){
                    Debug.Log("affecting " + collider.gameObject.name);
                    affect(collider.gameObject);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") || other.CompareTag("Monster") ){
            Debug.Log("affecting " + other.gameObject.name);
            affect(other.gameObject);
        }
    }

    IEnumerator disappearAfterDuration(){
        yield return new WaitForSeconds(explosionDuration);
        Destroy(gameObject);
    }

    public abstract void affect(GameObject obj);
}
