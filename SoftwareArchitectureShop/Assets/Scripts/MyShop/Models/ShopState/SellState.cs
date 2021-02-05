using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellState : IShopActions
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
        Debug.Log("Sell");
        Item previousItem = shopModel.SelectLastItem();
        shopModel.playerInventory.TransferItem(previousItem, shopModel.shopInventory);
        //onInventoryUpdate?.Invoke();
    }
}
