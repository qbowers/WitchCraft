using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject playerPrefab;


    public void StartLevel() {
        // Find the player start pad in the world
        // TODO: consider using tags or labels or layers or something. IDK.
        Transform startPad = GameObject.Find("StartPad").GetComponent<Transform>();


        // Spawn the player at start pad
        Instantiate(playerPrefab, startPad.position, Quaternion.identity);
        
        // Start enemies, any other world components
    }

    public void Pause() {
        // disable any movement input
        // poke scene_manager.menu_manager
    }

    public void Resume() {
        // enable movement input
    }
}