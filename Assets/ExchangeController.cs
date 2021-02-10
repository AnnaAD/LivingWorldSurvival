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
    // Start is called before the first frame update
    void Start()
    {
        toggleInventory = false;
        npcInventory = null;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            toggleInventory = !toggleInventory;
            Vector3 p1 = GameObject.Find("Player").transform.position;
            float distanceToObstacle = 0;
            RaycastHit[] hit = Physics.SphereCastAll(p1, 4f, GameObject.Find("Player").transform.forward, 4f);



            npcInventory = null;
            if (toggleInventory && hit.Length > 0)
            {
                foreach ( RaycastHit r in hit)
                {
                    if(r.collider.tag == "NPC")
                    {
                        Debug.Log("found NPC");
                        npcInventory = r.collider.gameObject.GetComponent<controlNPC>().inventory;
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

            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pInventory = GameObject.Find("Player").GetComponent<PlayerPickup>().inventory;

                npc_inventory.GetComponent<UI_Inventory>().setInventory(npcInventory);
                player_inventory.GetComponent<UI_Inventory>().setInventory(pInventory);
            }
        }
        player_inventory.gameObject.SetActive(toggleInventory);
        npc_inventory.gameObject.SetActive(toggleInventory);




    }
    public void updateInventories(Inventory player_inv, Inventory npc_inv)
    {
        pInventory = player_inv;
        npcInventory = npc_inv;
    }
}
