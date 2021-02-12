﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeController : MonoBehaviour
{
    [SerializeField] private GameObject player_inventory;
    [SerializeField] private GameObject npc_inventory;
    private bool toggleInventory;
    private Inventory pInventory;
    private Inventory npcInventory;
    private GameObject activeNpc;

    public Inventory selectedFromPlayer;
    public Inventory selectedFromNPC;

    // Start is called before the first frame update
    void Start()
    {
        toggleInventory = false;
        npcInventory = null;
        npc_inventory.GetComponent<UI_Inventory>().type = InventoryType.Exchange;
        player_inventory.GetComponent<UI_Inventory>().type = InventoryType.Exchange;
        activeNpc = null;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            toggleInventory = !toggleInventory;
            Vector3 p1 = GameObject.Find("Player").transform.position;
            // float distanceToObstacle = 0;
            RaycastHit[] hit = Physics.SphereCastAll(p1, 4f, GameObject.Find("Player").transform.forward, 4f);
            pInventory = GameObject.Find("Player").GetComponent<PlayerPickup>().inventory;



            npcInventory = null;
            if (toggleInventory && hit.Length > 0)
            {
                foreach ( RaycastHit r in hit)
                {
                    if(r.collider.tag == "NPC")
                    {
                        Debug.Log("found NPC" + r.collider.name);
                        npcInventory = r.collider.gameObject.GetComponent<controlNPC>().inventory;
                        activeNpc = r.collider.gameObject;
                    }
                }
            }

            if(npcInventory == null)
            {
                toggleInventory = false;
            }

            if (!toggleInventory)
            {

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                activeNpc = null;

            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                npc_inventory.GetComponent<UI_Inventory>().setInventory(npcInventory);
            }
        }
        player_inventory.gameObject.SetActive(toggleInventory);
        npc_inventory.gameObject.SetActive(toggleInventory);


    }

    public void SubmitTrade()
    {
        float npcVal = activeNpc.GetComponent<controlNPC>().evalItems(npc_inventory.GetComponent<UI_Inventory>().selectedItems);
        float playerVal = activeNpc.GetComponent<controlNPC>().evalItems(player_inventory.GetComponent<UI_Inventory>().selectedItems);

        Debug.Log(player_inventory);

        if(playerVal > npcVal)
        {
            foreach(Item i in player_inventory.GetComponent<UI_Inventory>().selectedItems.GetItems())
            {
                npcInventory.addItem(i);
                pInventory.removeItem(i);
            }

            foreach (Item i in npc_inventory.GetComponent<UI_Inventory>().selectedItems.GetItems())
            {
                npcInventory.removeItem(i);
                pInventory.addItem(i);
            }
        }
    }

    public void updateInventories(Inventory player_inv, Inventory npc_inv)
    {
        pInventory = player_inv;
        npcInventory = npc_inv;
    }
}
