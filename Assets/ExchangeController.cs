using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeController : MonoBehaviour
{
    [SerializeField] private GameObject player_inventory;
    [SerializeField] private GameObject npc_inventory;
    private bool toggleInventory;
    // Start is called before the first frame update
    void Start()
    {
        toggleInventory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            toggleInventory = !toggleInventory;
            if (!toggleInventory)
            {

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                npc_inventory.GetComponent<UI_Inventory>().setInventory(GameObject.Find("NPC").GetComponent<PlayerPickup>().inventory);
                player_inventory.GetComponent<UI_Inventory>().setInventory(GameObject.Find("Player").GetComponent<PlayerPickup>().inventory);
            }
        }
        player_inventory.gameObject.SetActive(toggleInventory);
        npc_inventory.gameObject.SetActive(toggleInventory);

        


    }
}
