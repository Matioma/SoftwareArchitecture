using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected ShopModel shopShopModel;

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
}
