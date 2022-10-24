using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CoreManager : MonoBehaviour {
    public static CoreManager instance = null;

    
    public string openLevel = Constants.LevelOne; 

    public LevelManager levelManager;

    public PlayerControls playerControls;
    public PlayerControls.OverarchingActions controlMap;
    public PlayerControls.PlayerActions playerMap;


    // Change this flag to switch between FPS and platformer controls
    public bool debug_controlModeMouse = false;

    public void Awake() {
        if (CoreManager.instance != null) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            CoreManager.instance = this;

            // Required to allow both AIM and MOVE input actions to reference the left/right arrow keys
            InputSystem.settings.SetInternalFeatureFlag("DISABLE_SHORTCUT_SUPPORT", true);

            SpawnManagers();
        }
    }

    public void SpawnManagers() {
        // Inputsystem
        playerControls = new PlayerControls();
        controlMap = playerControls.Overarching;
        playerMap = playerControls.Player;
        
        string filter = this.debug_controlModeMouse ? "FPS_player" : "Platformer_player";
        var bindingGroup = playerControls.controlSchemes.First(x => x.name == filter).bindingGroup;
        
        // Set as binding mask on actions. Any binding that doesn't match the mask will be ignored.
        playerControls.bindingMask = InputBinding.MaskByGroup(bindingGroup);


        // Find or create instances of all other required managers, DontDestroyOnLoad as required
        // e.g. audiomanager, levelmanager, etc.

        this.levelManager = FindOrCreate<LevelManager>();
    }

    public T FindOrCreate<T>() where T:Component {
        // Find existing component
        T component = gameObject.GetComponent<T>();
        // If its not there, create it
        if (component == null) {
            component = gameObject.AddComponent<T>();
        }

        return component;
    } 


    public void LoadLevel(string levelName) {
        // if level systems don't exist, load them
        SceneManager.LoadScene(Constants.LevelSystemsScene, LoadSceneMode.Single);
        // additively load scene
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
        // ping the levelmanager that the level is open
        this.levelManager.StartLevel();

        this.openLevel = levelName;
    }

    public void UnloadAllMenus() {
        foreach (string name in Constants.Menus) {
            Debug.Log("Killing menu:");
            Debug.Log(name);
            SceneManager.UnloadSceneAsync(name);
        }
    }
    public void UnloadLevel() {
        SceneManager.UnloadSceneAsync(Constants.LevelSystemsScene);
        SceneManager.UnloadSceneAsync(this.openLevel);
    }
    public void RestartLevel() {
        LoadLevel(this.openLevel);
    }


    public void LoadMenu(string menuName, LoadSceneMode mode = LoadSceneMode.Additive) {
        SceneManager.LoadScene(menuName, mode);
    }
    public void UnloadMenu(string menuName) {
        SceneManager.UnloadSceneAsync(menuName);
    }

    public void Pause() {
        this.levelManager.Pause();
        LoadMenu(Constants.PauseMenuScene);
    }

    public void Resume() {
        // TODO: unload pause menu
        this.levelManager.Resume();
    }

    public void ExitGame() {
        // do any required cleanup

        // https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL("http://google.com");
        #else
        Application.Quit();
        #endif
    }

}