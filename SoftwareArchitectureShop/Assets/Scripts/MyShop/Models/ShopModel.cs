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


    private ItemsCategory currentCategory = ItemsCategory.All;

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





    public List<Item> GetItems() {
        //return activeInvetory.GetItems();


        List<Item> items = new List<Item>();

        switch (currentCategory) {
            case ItemsCategory.All:
                items = shopInventory.GetItems(typeof(Item));
                break;
            case ItemsCategory.Potion:
                items = shopInventory.GetItems(typeof(Potion));
                break;
            case ItemsCategory.Weapon:
                items = shopInventory.GetItems(typeof(Weapon));
                break;
            case ItemsCategory.Armor:
                items = shopInventory.GetItems(typeof(Armor));
                break;
            default:
                Debug.LogError("Tried to get unknown category");
                break;
        }
        return items;
    }

    public void DeselectLastItem()
    {
        if (selectedItem != null)
        {
            selectedItem.IsSelected = false;
            selectedItem = null;
        }
    }

    public void SelectItem(Item item)
    {
        if (item == null) {
            return;
        }
        DeselectLastItem();

        selectedItem = item;
        selectedItem.IsSelected = true;
        onInventoryUpdate?.Invoke();
    }

    public void SelectCategory(ItemsCategory catergory)
    {
        DeselectLastItem();

        currentCategory = catergory;
        onInventoryUpdate?.Invoke();
    }

    public void Buy()
    {
        if (selectedItem == null) return;

        shopInventory.TransferItem(selectedItem, playerInventory);
        onInventoryUpdate?.Invoke();
    }
}


