using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject ui_inventory;
    private bool toggleInventory;
    // Start is called before the first frame update
    void Start()
    {
        toggleInventory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            toggleInventory = !toggleInventory;
        }
        ui_inventory.gameObject.SetActive(toggleInventory);
    }
}
