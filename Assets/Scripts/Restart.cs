using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    private PlayerControls playerControls;
    private PlayerControls.PlayerActions playerMap;

    void Awake (){
        playerControls = new PlayerControls();
        playerMap = playerControls.Player;
    }

    void OnEnable(){
        playerMap.Enable();
        playerMap.Restart.performed += (context) => {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        };
    }
}
