// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class NPCPickup : MonoBehaviour
// {
//     public Inventory inventory;
//     [SerializeField] private UI_Inventory ui_inventory = null;
//     // Start is called before the first frame update
//     void Start()
//     {
//         inventory = new Inventory();
//         if(ui_inventory != null)
//         {
//             ui_inventory.setInventory(inventory);
//         }
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//
//     }
//
//     private void OnTriggerEnter(Collider collision)
//     {
//         if (collision.transform.tag.Equals("Pickup"))
//         {
//             inventory.addItem(collision.gameObject.GetComponent<Pickup>().getItem());
//             if (ui_inventory != null)
//             {
//                 ui_inventory.setInventory(inventory);
//             }
//             Destroy(collision.gameObject);
//         }
//
//         if (collision.transform.tag.Equals("food"))
//         {
//             inventory.addItem(collision.gameObject.GetComponent<Pickup>().getItem());
//             if (ui_inventory != null)
//             {
//                 ui_inventory.setInventory(inventory);
//             }
//             Destroy(collision.gameObject);
//         }
//     }
// }
