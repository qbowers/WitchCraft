using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float speed = 1.0f;

    void Awake() {
        transform.position = new Vector3(-13.0f, 0.0f, 0.0f);
    }

    void FixedUpdate() {
        var playerPosition = GameObject.Find("Player").transform.position;

        var step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);


    }
}
