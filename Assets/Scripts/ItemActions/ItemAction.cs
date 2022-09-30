using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{
    public string costName;
    public int costCnt;
    protected CharacterController2D controller;

    void Awake(){
        controller = GetComponent<CharacterController2D>();
    }

    public bool cost(Inventory inv){
        return inv.subtractItemCnt(costName, costCnt);
    }
}
