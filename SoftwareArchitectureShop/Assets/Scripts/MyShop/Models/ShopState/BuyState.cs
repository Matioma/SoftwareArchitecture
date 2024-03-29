﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyState : IShopStateActions
{
    public List<Item> GetShopItems(ShopModel shopModel)
    {
        return shopModel.shopInventory.GetItems(shopModel.selectedCategory);
    }

    public void PerformAction(ShopModel shopModel)
    {
        if (shopModel.selectedItem == null) return;

        if (!shopModel.playerInventory.SpendMoney(shopModel.selectedItem.Price))
        {
            Debug.Log("Item could not be purchased");
            return;
        }
        Item previousItem = shopModel.SelectLastItem();
        shopModel.shopInventory.TransferItem(previousItem, shopModel.playerInventory);
    }
}
