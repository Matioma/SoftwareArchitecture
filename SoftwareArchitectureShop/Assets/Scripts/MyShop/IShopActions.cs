using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopActions
{
    void PerformAction(ShopModel shopModel);

    List<Item> GetShopItems(ShopModel shopModel);

}
