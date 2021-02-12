using System.Collections;
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
        pInventory = GameObject.Find("Player").GetComponent<PlayerPickup>().inventory;
        activeNpc = null;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("trying to find npc");
            toggleInventory = !toggleInventory;
            npcInventory = FindClosestNPC().GetComponent<controlNPC>().inventory;
            activeNpc = FindClosestNPC();

            if (npcInventory == null)
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
            foreach (Item i in npcInventory.GetItems())
            {
                Debug.Log(i.itemType + " " + i.amount);
            }
            foreach (Item i in player_inventory.GetComponent<UI_Inventory>().selectedItems.GetItems())
            {
         
                npcInventory.addItem(new Item(i.itemType, i.amount));
            }
            foreach (Item i in npc_inventory.GetComponent<UI_Inventory>().selectedItems.GetItems())
            {
            
                pInventory.addItem(new Item(i.itemType, i.amount));
            }

            foreach (Item i in player_inventory.GetComponent<UI_Inventory>().selectedItems.GetItems())
            {
                
                pInventory.removeItem(new Item(i.itemType, i.amount));
            }

            foreach (Item i in npc_inventory.GetComponent<UI_Inventory>().selectedItems.GetItems())
            {
               
                npcInventory.removeItem(new Item(i.itemType, i.amount));
            }
           
       }
        npc_inventory.GetComponent<UI_Inventory>().selectedItems.clearItems();
        player_inventory.GetComponent<UI_Inventory>().selectedItems.clearItems();


    }

    public GameObject FindClosestNPC()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("NPC");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = GameObject.Find("Player").transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
