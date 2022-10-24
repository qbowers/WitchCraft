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
    public ItemAction currentAction;

    void Start () {
        bindActions();
    }

    public void bindActions() {
        playerControls = CoreManager.instance.playerControls;
        playerMap = playerControls.Player;
        
        for (int i = 0; i < actions.Length; i++) {
            ItemAction action = actions[i];
            InputAction playerMapAction = playerControls.FindAction(action.actionName, false);
            playerMapAction.performed += (context) => {
                if (CoreManager.instance.bindingGroupFilter == Constants.mouseAimBinding) {
                    currentAction = action;
                }
                else if (CoreManager.instance.bindingGroupFilter == Constants.keyboardAimBinding) {
                    if (action.cost(inv)){
                        Transform firePoint = action.firePoint;
                        PotionProjectile proj = Instantiate<PotionProjectile>(action.potionPrefab, firePoint.position, firePoint.rotation);
                        proj.direction = GetAimDirection();
                        proj.move();
                    }
                }
            };
        }
        currentAction = actions[0];
    }


    Vector2 GetAimDirection() {
        if (CoreManager.instance.bindingGroupFilter == Constants.keyboardAimBinding) {
            Vector2 transformPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(playerMap.MousePos.ReadValue<Vector2>());
            return (mousePos - transformPos).normalized;
        } else {
            return playerMap.Aim.ReadValue<Vector2>();
        }
    }
}
