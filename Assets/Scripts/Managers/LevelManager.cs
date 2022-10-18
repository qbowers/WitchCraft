using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject playerPrefab;
    public bool paused = false;


    private PlayerControls.OverarchingActions controlMap;
    private PlayerControls.PlayerActions playerMap;


    void Awake () {
        controlMap = CoreManager.instance.playerControls.Overarching;
        playerMap = CoreManager.instance.playerControls.Player;

        Debug.Log(playerMap.Move);

        controlMap.Enable();
        playerMap.Enable();


        controlMap.TogglePause.performed += (context) => {
            
            if (!this.paused) Pause();
            else Resume();
        };
    }

    public void StartLevel() {
        Play();
        // Find the player start pad in the world
        // TODO: consider using tags or labels or layers or something. IDK.
        // Transform startPad = GameObject.Find("StartPad").GetComponent<Transform>();


        // Spawn the player at start pad
        // Instantiate(playerPrefab, startPad.position, Quaternion.identity);
        
        // Start enemies, any other world components
    }

    public void Pause() {
        Debug.Log("Pause!");
        this.paused = true;
        // disable any movement input
        this.playerMap.Disable();
        Time.timeScale = 0;
        CoreManager.instance.LoadMenu(Constants.PauseMenuScene);
        // poke scene_manager.menu_manager
    }
    public void Play() {
        Debug.Log("UnPause!");
        this.paused = false;
        this.playerMap.Enable();
        Time.timeScale = 1;
    }
    public void Resume() {
        Play();
        CoreManager.instance.UnloadMenu(Constants.PauseMenuScene);
        // enable movement input
    }
}