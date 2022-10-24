using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    // TODO: rename appropriately. Managers should be singletons. this is an interface that connects menus to appropriate managers

    // instantiated with each menu scene; there may be more than one of these in the world
    // Refers to CoreManager singleton, of which there will only be one

    public void Restart() {
        CoreManager.instance.RestartLevel();
    }

    public void ReturnToMainMenu() {
        CoreManager.instance.LoadMenu(Constants.StartMenuScene, LoadSceneMode.Single);
    }

    public void ExitGame() {
        CoreManager.instance.ExitGame();
    }

    public void Resume() {
        CoreManager.instance.Resume();
    }
    public void Pause() {
        CoreManager.instance.LoadMenu(Constants.PauseMenuScene, LoadSceneMode.Additive);
        CoreManager.instance.Pause();
    }

    public void LoadLevel() {
        CoreManager.instance.LoadLevel(Constants.LevelOne);
    }
}