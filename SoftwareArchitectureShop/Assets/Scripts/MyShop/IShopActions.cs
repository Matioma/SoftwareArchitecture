using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopActions 
{
    void SelectItem(Item item);

    void SelectCategory(ItemsCategory catergory);

    void Buy();
}
