using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : BaseController, IShopKeyboardActions
{
    IShopKeyboardActions shopKeyboardActions;

    private void Awake()
    {
        base.Awake();
        //shopShopModel = FindObjectOfType<ShopModel>();
        shopKeyboardActions = shopShopModel.GetComponent<IShopKeyboardActions>();
        if (shopKeyboardActions == null)
        {
            Debug.LogError("Shop Model was not created");
        }
    }

    public void SelectNextCategory()
    {
        shopKeyboardActions.SelectNextCategory();
    }

    public void SelectNextItem()
    {
        shopKeyboardActions.SelectNextItem();
    }

    public void SelectPreviousCategory()
    {
        shopKeyboardActions.SelectPreviousCategory();
    }

    public void SelectPreviousItem()
    {
        shopKeyboardActions.SelectPreviousItem();
    }





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            PerformAction();
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            SelectPreviousCategory();
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            SelectNextCategory();
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            SelectNextItem();
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            SelectPreviousItem();
        }
    }

    public void Buy()
    {
        throw new System.NotImplementedException();
    }
}
