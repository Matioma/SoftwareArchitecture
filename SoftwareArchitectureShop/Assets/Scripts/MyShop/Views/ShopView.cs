using System.Collections;
using System.Collections.Generic;
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
        shopModel.onInventoryUpdate += updateItemPanel;
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
    }

    void PopulateGridView()
    {
        //ClearView();
        foreach(var item in shopModel.GetShopItems()) {
            AddGridItemToView(item);
        }
    }

    void PopulateListView() {
        //ClearView();
        foreach (var item in shopModel.GetShopItems())
        {
            AddListItemToView(item);
        }
    }

    void updateItemPanel() {
        if (shopModel.SelectedItem == null) return;
        panelView.SetItemData(shopModel.SelectedItem);
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
        shopModel.onInventoryUpdate -= updateItemPanel;
    }
}
