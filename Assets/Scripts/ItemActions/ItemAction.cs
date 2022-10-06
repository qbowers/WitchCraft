using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAction : MonoBehaviour {
    protected CharacterController2D controller;
    public UDictionary<string, int> costs;

    void Awake() {
        controller = GetComponent<CharacterController2D>();
    }

    public bool cost(Inventory inv) {
        foreach(var item in costs) {
            string costName = item.Key;
            int costCnt = item.Value;
            Debug.Log("Action Cost:" + costName + " " + costCnt);
            if(!inv.canUse(costName, costCnt)){
                return false;
            }
        }
        inv.actionCosts(costs);
        return true;
    }

    public abstract void perform();
}
