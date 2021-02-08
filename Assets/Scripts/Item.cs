using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Stone,
        Stick,
        Mushroom,
        Meat,
        Matches,
        Tent,
    }

    public ItemType itemType;
    public int amount;


    public Sprite getSprite()
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Stick: return ItemAssets.Instance.stickSprite;
            case Item.ItemType.Stone: return ItemAssets.Instance.stoneSprite;
            case Item.ItemType.Mushroom: return ItemAssets.Instance.mushroomSprite;
            case Item.ItemType.Meat: return ItemAssets.Instance.meatSprite;
            case Item.ItemType.Matches: return ItemAssets.Instance.matchesSprite;
            case Item.ItemType.Tent: return ItemAssets.Instance.tentSprite;


        }

    }

    public GameObject getPickup()
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Stick: return ItemAssets.Instance.stickPrefab;
            case Item.ItemType.Stone: return ItemAssets.Instance.stonePrefab;
            case Item.ItemType.Mushroom: return ItemAssets.Instance.mushroomPrefab;
            case Item.ItemType.Meat: return ItemAssets.Instance.meatPrefab;
            case Item.ItemType.Matches: return ItemAssets.Instance.matchesPrefab;
            case Item.ItemType.Tent: return ItemAssets.Instance.tentPrefab;


        }

    }

    public bool isStackable()
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Stick:
            case Item.ItemType.Stone:
            case Item.ItemType.Mushroom:
            case Item.ItemType.Meat:
            case Item.ItemType.Matches:
                return true;
            case Item.ItemType.Tent:
                return ItemAssets.Instance.tentSprite;
                return false;
        }
    }

    public GameObject getDeployedTent()
    {
        return ItemAssets.Instance.deployedTent;
    }
}
