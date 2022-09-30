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
    public void collectInv(Item item)
    {
        if (!item.collected){
            int cnt = getItemCnt(item.id);
            inv[item.id] = cnt + item.cnt;
            Debug.Log(inv[item.id]+ " " + item.id + " in inv");
            item.collected = true;
        } 
    }

    public bool subtractItemCnt(string costName, int costCnt){
        Debug.Log("cost " + costName + costCnt);
        if(inv.ContainsKey(costName) && inv[costName] >= costCnt){
            inv[costName] -= costCnt;
            Debug.Log(inv[costName]);
            return true;
        }
        return false;
    }
}
