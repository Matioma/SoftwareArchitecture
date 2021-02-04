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

    private void Awake()
    {
        shopModel = FindObjectOfType<ShopModel>();
        if (shopModel == null) {
            Debug.LogError("There is no Shop Model in the scene");
        }

        shopModel.onInventoryUpdate += PopulateTheView;
    }


    private void Start()
    {
        PopulateTheView();
    }


    void ClearView() {
        while (gridItemsContainer.transform.childCount > 0)
        {
            DestroyImmediate(gridItemsContainer.transform.GetChild(0).gameObject);
        }
    }
    void PopulateTheView()
    {
        ClearView();
        foreach(var item in shopModel.GetShopItems()) {
            AddItemToView(item);
        }
    }

    void AddItemToView(Item newItem) {
       GameObject itemObj = Instantiate(gridItemPrefab, gridItemsContainer.transform);
       itemObj.GetComponent<ItemView>().SetItemData(newItem);
       itemObj.GetComponent<ItemView>().Display();
    }

    private void OnDestroy()
    {
        shopModel.onInventoryUpdate -= PopulateTheView;
    }
}
