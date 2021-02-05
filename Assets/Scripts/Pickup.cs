using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Item.ItemType itemType;
    private Item item;

    private void Start()
    {
        item = new Item { itemType = itemType, amount = 1 };
    }

    public Item getItem()
    {
        return item;
    } 
}
