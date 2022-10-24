using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour {
    public UDictionary<string, int> costs;
    public PotionProjectile potionPrefab;
    public string actionName;
    [HideInInspector]
    public Transform firePoint;

    void Awake(){
        firePoint = this.gameObject.transform.GetChild(0);
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
}
