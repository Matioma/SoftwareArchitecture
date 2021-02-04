﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : BaseController, IPointerClickHandler,IShopMouseActions
{
    IShopMouseActions shopMouseAction;

    private void Awake()
    {
        base.Awake();
        //shopShopModel = FindObjectOfType<ShopModel>();
        shopMouseAction = shopShopModel.GetComponent<IShopMouseActions>();
        if (shopMouseAction == null) {
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

    public void SelectItem(Item item)
    {
        shopMouseAction.SelectItem(item);
    }

    public void SelectionCategory(string category) {
        ItemsCategory itemCategory;

        if (Enum.TryParse(category, true, out itemCategory))
        {
            SelectCategory(itemCategory);
        }
        else {
            Debug.LogError("THe category is wrong");
        }
    }
    public void SelectCategory(ItemsCategory catergory)
    {
        shopMouseAction.SelectCategory(catergory);
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
        shopMouseAction.SelectShopType(shopType);
    }
}
