using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAction : MonoBehaviour {
    public UDictionary<string, int> costs;
    public abstract string keybind { get; }

    protected CharacterMovement controller;
    void Awake() {
        controller = GetComponent<CharacterMovement>();
    }

    public bool cost(Inventory inv) {
        foreach(var item in costs) {
            string costName = item.Key;
            int costCnt = item.Value;
            Debug.Log("Action Cost:" + costName + " " + costCnt);
            if(!inv.enough(costName, costCnt)){
                return false;
            }
        }
        inv.actionCosts(costs);
        return true;
    }

    public abstract void perform();
}
