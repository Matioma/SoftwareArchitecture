using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemRarity { 
    Basic=0,
    Good,
    Rare,
    Mythic,
    Legendary
}


[System.Serializable]
public abstract class Item
{
    [SerializeField]
    public string Name;
    public string spriteFile;

    private int price = 0;
    public int Price { 
        get {
            return price;
        }
        set {
            SellPrice = (int)((float)value * 0.8);
            price = value;
        } 
    }
    public string attributes="Random Attribute";
    public List<string> echantements = new List<string>();
    public string description;
    public ItemRarity rarity;


    //private int sellPrice;

    public int SellPrice { get; protected set; } = 10;

    public int upgradePriceRatio = 2;

    public int UpgradePrice { get; protected set; } = 10;
    public int UpgardeLevel { get;protected set; } = 1;



    public virtual void Upgrade() {
        UpgradePrice *= upgradePriceRatio;
        UpgardeLevel++;
    }


    public bool IsSelected {get;set;}= false;

    protected Item(string name ="Default Name", string FilePath="items_0", int cost=0) {
        Name = name;
        spriteFile = FilePath;
        this.Price = cost;
    }
}
