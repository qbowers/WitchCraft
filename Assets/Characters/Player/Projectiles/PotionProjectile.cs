using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionProjectile : MonoBehaviour {
    public float duration;
    public float speed;
    private float speedMult;
    public float arc;
    public PotionExplosion explosion;
    [HideInInspector]
    public Vector2 direction;
    private new Rigidbody2D rigidbody2D;
    
    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(destroyAfterDuration());
    }

    private IEnumerator destroyAfterDuration(){
        yield return new WaitForSeconds(duration);
        if (gameObject != null){
            Destroy(gameObject);
        }
    }

    public void move(){
        if (direction.y > 0){
            speedMult = 0.75f * speed;
        }
        else {
            speedMult = speed;
        }
        rigidbody2D.velocity = direction * speedMult;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // layer id = 3
        if (collision.gameObject.layer == 3 || collision.CompareTag("Monster")) {
            Instantiate<PotionExplosion>(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
