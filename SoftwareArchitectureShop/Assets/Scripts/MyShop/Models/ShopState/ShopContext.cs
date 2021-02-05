using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopContext : IShopActions
{
    IShopActions currentState;

    public ShopContext() { }

    public List<Item> GetShopItems(ShopModel shopModel)
    {
        return currentState.GetShopItems(shopModel);
    }

    public void PerformAction(ShopModel shopModel )
    {
        currentState.PerformAction(shopModel);
    }

    public void setShopState(IShopActions currentState)
    {
        this.currentState = currentState;
    }
}

