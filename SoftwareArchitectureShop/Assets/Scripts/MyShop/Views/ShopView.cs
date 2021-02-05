using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    ShopModel shopModel;

    List<Item> itemsToDisplay;


    [SerializeField]
    GameObject gridItemPrefab;
    [SerializeField]
    GameObject gridItemsContainer;


    [SerializeField]
    GameObject listItemPrefab;
    [SerializeField]
    GameObject listItemsContainer;



    [SerializeField]
    ItemInfoPanelView panelView;


    [SerializeField]
    TextMeshProUGUI[] balanceDisplay;

    private void Awake()
    {
      
    }


    private void Start()
    {
        shopModel = FindObjectOfType<ShopModel>();
        if (shopModel == null)
        {
            Debug.LogError("There is no Shop Model in the scene");
        }

        shopModel.onInventoryUpdate += updateViews;
        shopModel.onInventoryUpdate += updateItemPanelData;
        updateViews();
    }


    void ClearView() { 
        if(gridItemsContainer != null){
            while (gridItemsContainer.transform.childCount > 0)
            {
                DestroyImmediate(gridItemsContainer.transform.GetChild(0).gameObject);
            }
        }
        

        if (listItemsContainer != null) {
            while (listItemsContainer.transform.childCount > 0)
            {
                DestroyImmediate(listItemsContainer.transform.GetChild(0).gameObject);
            }
        }
      
    }

    void updateViews() {
        ClearView();
        PopulateGridView();
        PopulateListView();
        updateBalanceText();
    }

    void PopulateGridView()
    {
        foreach(var item in shopModel.GetShopItems()) {
            AddGridItemToView(item);
        }
    }
    void PopulateListView() {
        foreach (var item in shopModel.GetShopItems())
        {
            AddListItemToView(item);
        }
    }


    //Updates the item data in list view
    void updateItemPanelData() {
        if (shopModel.SelectedItem == null) return;
        panelView.SetItemData(shopModel.SelectedItem);
    }


    void updateBalanceText() { 
        foreach(var textMesh in balanceDisplay)
        {
            textMesh.text = shopModel.GetBalance().ToString();
        }
    
    }


    void AddListItemToView(Item newItem) {
        GameObject itemObj = Instantiate(listItemPrefab, listItemsContainer.transform);
        itemObj.GetComponentInChildren<ItemView>().SetItemData(newItem);
        itemObj.GetComponentInChildren<ItemView>().Display();
    }


    void AddGridItemToView(Item newItem) {
       GameObject itemObj = Instantiate(gridItemPrefab, gridItemsContainer.transform);
       itemObj.GetComponent<ItemView>().SetItemData(newItem);
       itemObj.GetComponent<ItemView>().Display();
    }

    private void OnDestroy()
    {
        //shopModel.onInventoryUpdate -= PopulateGridView;
        //shopModel.onInventoryUpdate -= PopulateListView;

        shopModel.onInventoryUpdate -= updateViews;
        shopModel.onInventoryUpdate -= updateItemPanelData;
    }
}
