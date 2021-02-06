using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ItemsCategory{ 
    All=0,
    Armor=1,
    Weapon=2,
    Potion=3
}


[Serializable]
public class Inventory
{
    [SerializeField]
    List<Item> items = new List<Item>();

    [SerializeField]
    int currencyBalance = 0;

    public int getBalance() {
        return currencyBalance;
    }

    public int Balance { 
        get { return currencyBalance; } 
        set { currencyBalance = value; } 
    }

    public List<Item> Items {
        get { return items; }
    }


    public Item getItem(int index) {
        if (items.Count == 0) return null;
        if (index < 0 || index > items.Count - 1) return null;
        
        return items[index];
    }

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

    public bool canBuy(int amount) {
        return currencyBalance >= amount;
    }

    //Spend user Money
    public bool SpendMoney(int amount) {
        if (canBuy(amount)) {
            currencyBalance -= amount;
            //Debug.Log(currencyBalance);
            return true;
        }
        return false;
    }
    
    public void TransferItem(Item item, Inventory destination) {
        destination.items.Add(item);
        this.items.Remove(item);
    }
}
