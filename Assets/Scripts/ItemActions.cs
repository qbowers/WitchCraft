using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ItemActions : MonoBehaviour
{
    private PlayerControls.PlayerActions playerMap;
    private PlayerControls playerControls;
    public Inventory inv;
    public Dash dash;

    void Awake (){
        playerControls = new PlayerControls();
        playerMap = playerControls.Player;
    }


    // Update is called once per frame
    void OnEnable(){
        playerMap.Enable();
        playerMap.Dash.performed += formatActionFunc(dash);
    }

    Action<InputAction.CallbackContext> formatActionFunc(Dash action){
        return (context) => {
            if (action.cost(inv)) {
                action.start();
            }
        };
    }
}
