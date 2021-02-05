﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeState : IShopActions
{
    public List<Item> GetShopItems(ShopModel shopModel)
    {
        return shopModel.playerInventory.GetItems(shopModel.selectedCategory);
    }

    public void PerformAction(ShopModel shopModel)
    {
        if (shopModel.selectedItem == null) return;

        //Debug.Log("item price is" + selectedItem.price);
        if (!shopModel.playerInventory.SpendMoney(shopModel.selectedItem.price))
        {
            Debug.Log("Item could not be purchased");
            return;
        }
        Item previousItem = shopModel.SelectLastItem();
        Debug.Log("To Do  Item Upgrading");
        //playerInventory.TransferItem(previousItem, shopInventory);
        //onInventoryUpdate?.Invoke();
    }
}