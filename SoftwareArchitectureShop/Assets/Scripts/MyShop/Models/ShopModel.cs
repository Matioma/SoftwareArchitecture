using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShopType { 
    Buy,
    Sell,
    Upgrade
}


public class ShopModel : MonoBehaviour, IShopMouseActions,IShopActions,IShopKeyboardActions
{
    [SerializeField]
    Inventory playerInventory;
    [SerializeField]
    Inventory shopInventory;
    ItemFactory itemFactory;


    private ItemsCategory selectedCategory = ItemsCategory.All;
    private Inventory activeInvetory;



    private ShopType currentShopType = ShopType.Buy;





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

    public void Buy()
    {
        if (selectedItem == null) return;

        //Debug.Log("item price is" + selectedItem.price);
        if (!playerInventory.SpendMoney(selectedItem.price))
        {
            Debug.Log("Item could not be purchased");
            return;
        }
        Item previousItem = SelectLastItem();
        shopInventory.TransferItem(previousItem, playerInventory);
        onInventoryUpdate?.Invoke();
    }
    public void Sell()
    {
        if (selectedItem == null) return;

        //Debug.Log("item price is" + selectedItem.price);
        if (!playerInventory.SpendMoney(selectedItem.price))
        {
            Debug.Log("Item could not be purchased");
            return;
        }
        Item previousItem = SelectLastItem();
        playerInventory.TransferItem(previousItem, shopInventory);
        onInventoryUpdate?.Invoke();
    }

    public void Upgrade()
    {
        if (selectedItem == null) return;

        //Debug.Log("item price is" + selectedItem.price);
        if (!playerInventory.SpendMoney(selectedItem.price))
        {
            Debug.Log("Item could not be purchased");
            return;
        }
        Item previousItem = SelectLastItem();
        Debug.Log("To Do  Item Upgrading");
        //playerInventory.TransferItem(previousItem, shopInventory);
        onInventoryUpdate?.Invoke();
    }

    public void SelectShopType(ShopType newShopType) {
        
        selectedCategory = ItemsCategory.All;
        currentShopType = newShopType;

        if (newShopType == ShopType.Sell || newShopType == ShopType.Upgrade)
        {
            activeInvetory = playerInventory;
        }
        else {
            activeInvetory = shopInventory;
        }
        onInventoryUpdate?.Invoke();
    }


    Item SelectLastItem() {
        if (selectedItem == null) return null;  // Nothing was selected

        Item currentItem = this.selectedItem; 


        List<Item> visibleItems = GetShopItems(); 
        int index =visibleItems.IndexOf(selectedItem);

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
    public void PerformAction()
    {
        switch (currentShopType){
            case ShopType.Buy:
                Buy();
                break;
            case ShopType.Sell:
                Sell();
                break;
            case ShopType.Upgrade:
                Upgrade();
                break;
        }
      
    }




    public void SelectNextCategory()
    {
        if (NextCategory(selectedCategory) == null) { 
            Debug.LogError("Unkown Category"); 
        }

        selectedCategory = NextCategory(selectedCategory).Value;
        onInventoryUpdate?.Invoke();
    }
    public void SelectPreviousCategory()
    {
        if (PreviousCategory(selectedCategory) == null)
        {
            Debug.LogError("Unkown Category");
        }

        selectedCategory = PreviousCategory(selectedCategory).Value;
        onInventoryUpdate?.Invoke();
    }
    public void SelectNextItem()
    {
        List<Item> visibleItems = GetShopItems();
        if (visibleItems.Count == 0) return; //

        if (selectedItem == null)
        {
            SelectItem(visibleItems[0]);
        }
        else {
            int index = visibleItems.IndexOf(selectedItem);
            SelectItem(visibleItems[(index + 1) % visibleItems.Count]);
        }
    }
    public void SelectPreviousItem()
    {
        List<Item> visibleItems = GetShopItems();
        if (visibleItems.Count == 0) return; //

        if (selectedItem == null)
        {
            SelectItem(visibleItems[0]);
        }
        else
        {
            int index = visibleItems.IndexOf(selectedItem);

            if (index - 1 < 0)
            {
                SelectItem(visibleItems[visibleItems.Count-1]);
            }
            else {
                SelectItem(visibleItems[(index - 1) % visibleItems.Count]);
            }


          
        }
    }






    //Utility function to get the next Category
    ItemsCategory? NextCategory(ItemsCategory category)
    {
        //ItemsCategory.
        switch (category)
        {

            case ItemsCategory.All:
                return ItemsCategory.Weapon;

            case ItemsCategory.Armor:
                return ItemsCategory.Potion;

            case ItemsCategory.Potion:
                return ItemsCategory.All;

            case ItemsCategory.Weapon:
                return ItemsCategory.Armor;

            default:
                Debug.LogError("Unknown Category");
                return null;

        }
    }

    //Utility function to get the previous Category
    ItemsCategory? PreviousCategory(ItemsCategory category)
    {
        //ItemsCategory.
        switch (category)
        {
            case ItemsCategory.All:
                return ItemsCategory.Potion;

            case ItemsCategory.Armor:
                return ItemsCategory.Weapon;

            case ItemsCategory.Potion:
                return ItemsCategory.Armor;

            case ItemsCategory.Weapon:
                return ItemsCategory.All;

            default:
                Debug.LogError("Unknown Category");
                return null;

        }
    }

}


