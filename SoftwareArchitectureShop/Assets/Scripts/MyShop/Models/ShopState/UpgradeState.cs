using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeState : IShopStateActions
{
    public List<Item> GetShopItems(ShopModel shopModel)
    {
        return shopModel.playerInventory.GetItems(shopModel.selectedCategory);
    }

    public void PerformAction(ShopModel shopModel)
    {
        if (shopModel.selectedItem == null) return;

        //Debug.Log("item price is" + selectedItem.price);
        if (!shopModel.playerInventory.SpendMoney(shopModel.selectedItem.UpgradePrice))
        {
            Debug.Log("Item could not be upgraded");
            return;
        }
        //Item previousItem = shopModel.SelectLastItem();

        shopModel.selectedItem.Upgrade();
        //previousItem.Upgrade();
        //playerInventory.TransferItem(previousItem, shopInventory);
        //onInventoryUpdate?.Invoke();
    }
}
