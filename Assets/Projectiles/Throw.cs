using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerControls.PlayerActions playerMap;
    public ItemActionsController actionController;
    private Inventory inv;
    private ItemAction currentAction;

    void Awake() {
        inv = GetComponent<Inventory>();
    }

    void Start () {
        playerMap = CoreManager.instance.playerMap;
        playerMap.Throw.performed += (context) => {
            currentAction = actionController.currentAction;
            if (currentAction.cost(inv)){
                Transform firePoint = currentAction.firePoint;
                PotionProjectile proj = Instantiate<PotionProjectile>(currentAction.potionPrefab, firePoint.position, firePoint.rotation);
                // proj.direction = playerMap.Aim.ReadValue<Vector2>();
                Vector2 transformPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(playerMap.MousePos.ReadValue<Vector2>());
                proj.direction = (mousePos - transformPos).normalized;
                proj.move();
            }
        };
    }
}
