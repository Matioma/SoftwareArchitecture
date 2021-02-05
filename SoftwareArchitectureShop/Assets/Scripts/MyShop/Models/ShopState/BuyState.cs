using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyState : IShopActions
{
    public List<Item> GetShopItems(ShopModel shopModel)
    {
        return shopModel.shopInventory.GetItems(shopModel.selectedCategory);
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
        Debug.Log("Buy");
        Item previousItem = shopModel.SelectLastItem();
        shopModel.shopInventory.TransferItem(previousItem, shopModel.playerInventory);
    }
}
