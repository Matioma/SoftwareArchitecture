using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ItemsCategory{ 
    All,
    Armor,
    Weapon,
    Potion
}


public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> items = new List<Item>();

    [SerializeField]
    int currency = 0;
    //ItemsCategory currentCategory = ItemsCategory.All;

    ushort selectedIndex = 0;


    

    public void AddItem(Item item) {
        items.Add(item);
    }

    //Return all invetory items of a specific type
    public List<Item> GetItems(Type type) {
        List<Item> itemsToGet = new List<Item>();
        foreach (var item in items) {        
            if (item.GetType().IsSubclassOf(type) || item.GetType() == type)
            {
                itemsToGet.Add(item);
            }
        }
        return itemsToGet;
    }

    //Return all visible items
    public List<Item> GetItems(ItemsCategory currentCategory)
    {
        List<Item> items = new List<Item>();

        switch (currentCategory)
        {
            case ItemsCategory.All:
                items = GetItems(typeof(Item));
                break;
            case ItemsCategory.Potion:
                items = GetItems(typeof(Potion));
                break;
            case ItemsCategory.Weapon:
                items = GetItems(typeof(Weapon));
                break;
            case ItemsCategory.Armor:
                items = GetItems(typeof(Armor));
                break;
            default:
                Debug.LogError("Tried to get unknown category");
                break;
        }
        return items;
    }
    public void TransferItem(Item item, Inventory destination) {
        destination.items.Add(item);
        items.Remove(item);
    }
}
