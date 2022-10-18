using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    private PlayerControls playerControls;
    private PlayerControls.PlayerActions playerMap;

    void Start () {
        playerMap = CoreManager.instance.playerMap;
    
        playerMap.Restart.performed += (context) => {
            SceneManager.LoadScene("LevelDesignDemo", LoadSceneMode.Single);
        };
    }
}
