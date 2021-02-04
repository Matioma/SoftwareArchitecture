using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel : MonoBehaviour, IShopActions
{
    [SerializeField]
    Inventory playerInventory;
    [SerializeField]
    Inventory shopInventory;
    ItemFactory itemFactory;


    private ItemsCategory selectedCategory = ItemsCategory.All;
    private Inventory activeInvetory;


    Item selectedItem = null;
    public event Action onInventoryUpdate;



    private void Awake()
    {
        activeInvetory = shopInventory;
        itemFactory = new ItemFactory();
        GenerateShopProducts();
    }

    void GenerateShopProducts() {
        for (int i = 0; i < 10; i++) {
            shopInventory.AddItem(itemFactory.CreateWeapon());
        }
        for (int i = 0; i < 10; i++)
        {
            shopInventory.AddItem(itemFactory.CreatePotion());
        }
        for (int i = 0; i < 10; i++)
        {
            shopInventory.AddItem(itemFactory.CreateArmor());
        }
    }


    //Return all the items of the currently selected inventory
    public List<Item> GetShopItems() {
        return activeInvetory.GetItems(selectedCategory);
    }

    Item SelectPreviousItem() {
        if (selectedItem == null) return null;  // Nothing was selected

        Item currentItem = this.selectedItem; 


        List<Item> visibleItems = GetShopItems(); 
        int index =visibleItems.IndexOf(selectedItem);
        Debug.Log(index);

        
        if (index==0) {
            if (visibleItems.Count > 0)
            {
                DeselectItem();
                SelectItem(visibleItems[index]);
                return currentItem;
            }


            DeselectItem();
            return currentItem;
        }

        if (index < 0) {
            
                return null;
           
        }


        DeselectItem();
        SelectItem(visibleItems[index - 1]);
        return currentItem;
        
    }
        

    public void DeselectItem()
    {
        if (selectedItem == null) return; 

        selectedItem.IsSelected = false;
        selectedItem = null;
    }

    public void SelectItem(Item item)
    {
        if (item == null) return;

        DeselectItem();
        selectedItem = item;
        selectedItem.IsSelected = true;
        onInventoryUpdate?.Invoke();
    }

    public void SelectCategory(ItemsCategory catergory)
    {
        DeselectItem();
        selectedCategory = catergory;
        onInventoryUpdate?.Invoke();
    }

    public void Buy()
    {
        if (selectedItem == null) return;


        Item previousItem =SelectPreviousItem();
        shopInventory.TransferItem(previousItem, playerInventory);
        onInventoryUpdate?.Invoke();
    }
}


