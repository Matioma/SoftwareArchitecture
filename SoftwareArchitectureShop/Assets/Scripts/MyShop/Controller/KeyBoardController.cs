using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : BaseController
{
    IShopKeyboardActions shopKeyboardActions;


    private void Start() {
        base.Start();
        shopKeyboardActions = FindObjectOfType<ShopModel>();
        if (shopKeyboardActions == null)
        {
            Debug.LogError("Shop Model was not created");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            PerformAction();
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            shopKeyboardActions.SelectPreviousCategory();
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            shopKeyboardActions.SelectNextCategory();
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            shopKeyboardActions.SelectNextItem();
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            shopKeyboardActions.SelectPreviousItem();
        }
    }

}
