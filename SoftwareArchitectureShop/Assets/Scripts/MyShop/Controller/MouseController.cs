using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : BaseController, IPointerClickHandler
{
    IShopMouseActions shopMouseAction;



    private void Start()
    {
        base.Start();

        shopMouseAction = FindObjectOfType<ShopModel>();
        if (shopMouseAction == null)
        {
            Debug.LogError("Shop Model was not created");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemView itemView = eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemView>();
        if(itemView != null)
        {
            shopMouseAction.SelectItem(itemView.GetItemData());
        }
    }


    public void SelectionCategory(string category) {
        ItemsCategory itemCategory;

        if (Enum.TryParse(category, true, out itemCategory))
        {
            shopMouseAction.SelectCategory(itemCategory);
            //SelectCategory(itemCategory);
        }
        else {
            Debug.LogError("THe category is wrong");
        }
    }
    public void Buy() {
        PerformAction();
    }



    public void SelectShopCategory(string category) {
        ShopType itemCategory;

        if (Enum.TryParse(category, true, out itemCategory))
        {
            SelectShopType(itemCategory);
        }
        else
        {
            Debug.LogError("The shop type is wrong");
        }
    }


    public void SelectShopType(ShopType shopType)
    {
        switch (shopType) {
            case ShopType.Buy:
                shopShopModel.SelectShopType(new BuyState());
                break;
            case ShopType.Sell:
                shopShopModel.SelectShopType(new SellState());
                break;
            case ShopType.Upgrade:
                shopShopModel.SelectShopType(new UpgradeState());
                break;
        }
    }
}
