using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinOnTouch : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player") {
            return;
        }

        CoreManager.instance.LoadMenu(Constants.WinMenuScene, LoadSceneMode.Single);
    }
}
