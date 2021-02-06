using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour,IShopMainAction
{
    protected IShopMainAction shopShopModel;

    protected void Awake()
    {
    }

    protected void Start()
    {
        shopShopModel = FindObjectOfType<ShopModel>();
       
    }
    public void PerformAction()
    {
        shopShopModel.PerformAction();
    }

    public void SelectShopType(IShopStateActions newShopState)
    {
        shopShopModel.SelectShopType(newShopState);
    }
}
