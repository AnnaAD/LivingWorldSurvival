using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] private UI_Inventory ui_inventory = null;
    [SerializeField] private UI_Inventory exchange_inventory = null;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        if(ui_inventory != null)
        {
            ui_inventory.setInventory(inventory);
            exchange_inventory.setInventory(inventory);

        }
    }

    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.transform.tag.Equals("Pickup") || collision.transform.tag.Equals("food"))
        {
            if(Input.GetKey(KeyCode.Return))
            {
                inventory.addItem(collision.gameObject.GetComponent<Pickup>().getItem());
                if (ui_inventory != null)
                {
                    ui_inventory.setInventory(inventory);
                }
                Destroy(collision.gameObject);
            }
        }
    }
}
