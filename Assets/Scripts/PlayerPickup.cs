using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private UI_Inventory ui_inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        ui_inventory.setInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag.Equals("Pickup"))
        {
            inventory.addItem(collision.gameObject.GetComponent<Pickup>().getItem());
            ui_inventory.setInventory(inventory);
            Destroy(collision.gameObject);
        }
    }
}
