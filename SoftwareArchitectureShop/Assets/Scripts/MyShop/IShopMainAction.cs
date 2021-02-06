using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopMainAction 
{
    void PerformAction();
    void SelectShopType(IShopStateActions newShopState);
}
