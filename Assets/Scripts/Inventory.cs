using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public Dictionary<string, int> inv = new Dictionary<string, int>();
    public int getItemCnt(string item) {
        if (inv.ContainsKey(item)) {
            return inv[item];
        }
        return 0;
    }
    public void collectInv(Item item) {
        if (!item.collected){
            int cnt = getItemCnt(item.id);
            inv[item.id] = cnt + item.cnt;
            Debug.Log(inv[item.id]+ " " + item.id + " in inv");
            item.collected = true;
        } 
    }

    public bool canUse(string costName, int costCnt) {
        if (costCnt == 0){
            return true;
        }
        if(inv.ContainsKey(costName) && inv[costName] >= costCnt){
            return true;
        }
        return false;
    }

    public void actionCosts(UDictionary<string, int> costs){
        foreach(var item in costs){
            string costName = item.Key;
            int costCnt = item.Value;
            inv[costName] -= costCnt;
        }
    }
}
