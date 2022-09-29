using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<string, int> inv = new Dictionary<string, int>();
    public int getItemCnt(string item){
        if (inv.ContainsKey(item)){
            return inv[item];
        }
        return 0;
    }
    public void updateInv(Item item)
    {
        if (!item.collected){
            int cnt = getItemCnt(item.id);
            inv[item.id] = cnt + item.cnt;
            Debug.Log(inv[item.id]+ " " + item.id + " in inv");
            item.collected = true;
        }
        
    }
}
