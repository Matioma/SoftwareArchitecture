using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour,IShopActions
{
    protected ShopModel shopShopModel;
    [SerializeField]
    protected IShopActions shopActions;

    protected void Awake()
    {
        shopShopModel = FindObjectOfType<ShopModel>();
        shopActions = shopShopModel.GetComponent<IShopActions>();
        if (shopActions == null)
        {
            Debug.LogError("Shop Model was not created");
        }
    }
    public void PerformAction()
    {
        shopActions.PerformAction();
    }
}
