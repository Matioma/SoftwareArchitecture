using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShopType { 
    Buy,
    Sell,
    Upgrade
}


public class ShopModel : MonoBehaviour, IShopMouseActions,IShopKeyboardActions,IShopMainAction
{

    [SerializeField]
    public Inventory playerInventory;
    [SerializeField]
    public Inventory shopInventory;
    ItemFactory itemFactory;


    public ItemsCategory selectedCategory = ItemsCategory.All;


    ShopContext shopContext=new ShopContext();


    public int GetBalance() {
        return playerInventory.getBalance();
    }


    public Item selectedItem = null;
    public Item SelectedItem { get { return selectedItem; }}
    
    public event Action onInventoryUpdate;



    private void Awake()
    {
        shopContext.setShopState(new BuyState());
        itemFactory = new ItemFactory();
        GenerateShopProducts();
    }


    /// <summary>
    /// Initilizes the shop inventory
    /// </summary>
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
        return shopContext.GetShopItems(this);
    }

   
    public void SelectShopType(ShopType newShopType) {
        
        selectedCategory = ItemsCategory.All;
        onInventoryUpdate?.Invoke();
    }

    public void SelectShopType(IShopStateActions newShopState)
    {
        shopContext.setShopState(newShopState);
        onInventoryUpdate?.Invoke();
    }

    //Selects the item to the left if current item sold/bought
    public Item SelectLastItem() {
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

    //Deselectes Currently selected Item
    public void DeselectItem()
    {
        if (selectedItem == null) return; 

        selectedItem.IsSelected = false;
        selectedItem = null;
    }
   
    //Makes an item selected
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


    //Perform the main shop action Buy/sell/upgrade
    public void PerformAction()
    {
        shopContext.PerformAction(this);
        onInventoryUpdate?.Invoke();
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
    //Selects the item to the left
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


