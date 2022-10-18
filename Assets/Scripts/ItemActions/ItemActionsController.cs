using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemActionsController : MonoBehaviour {

    private PlayerControls.PlayerActions playerMap;
    private PlayerControls playerControls;
    public Inventory inv;
    public ItemAction[] actions;

    void Start() {
        playerControls = CoreManager.instance.playerControls;
        playerMap = playerControls.Player;
        
        for (int i = 0; i < actions.Length; i++) {
            ItemAction action = actions[i];
            InputAction playerMapAction = playerControls.FindAction(action.GetType().Name, false);
            playerMapAction.performed += formatActionFunc(action);
        }
    }

    Action<InputAction.CallbackContext> formatActionFunc(ItemAction action) {
        return (context) => {
            Debug.Log(action.GetType().Name);
            if (action.cost(inv)) {
                action.perform();
            }
        };
    }
}
