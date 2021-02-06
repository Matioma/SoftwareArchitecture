using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopContext : IShopStateActions
{
    IShopStateActions currentState;

    public ShopContext() { }

    public List<Item> GetShopItems(ShopModel shopModel)
    {
        return currentState.GetShopItems(shopModel);
    }

    public void PerformAction(ShopModel shopModel )
    {
        currentState.PerformAction(shopModel);
    }

    public void setShopState(IShopStateActions currentState)
    {
        this.currentState = currentState;
    }
}

