using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour, IPointerClickHandler
{
    ShopModel shopShopModel;

    [SerializeField]
    IShopActions shopActions;

    [SerializeField]
    ItemsCategory items = ItemsCategory.Armor;


    private void Awake()
    {
        shopShopModel = FindObjectOfType<ShopModel>();
        shopActions = shopShopModel.GetComponent<IShopActions>();
        if (shopActions == null) {
            Debug.LogError("Shop Model was not created");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemView itemView = eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemView>();
        if(itemView != null)
        {
            shopActions.SelectItem(itemView.GetItemData());
        }
    }

    public void SelectItem(Item item)
    {
        shopActions.SelectItem(item);
    }

    public void SelectionCategory(string category) {
        ItemsCategory itemCategory;

        if (Enum.TryParse(category, true, out itemCategory))
        {
            shopActions.SelectCategory(itemCategory);
        }
        else {
            Debug.LogError("THe category is wrong");
        }
    }


    public void Buy() {
        shopActions.Buy();
    }

}
