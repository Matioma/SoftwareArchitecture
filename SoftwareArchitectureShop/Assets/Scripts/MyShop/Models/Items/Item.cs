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
    public int price = 0;
    public string attributes="Random Attribute";
    public List<string> echantements = new List<string>();
    public string description;
    public ItemRarity rarity;

    public bool IsSelected {get;set;}= false;

    protected Item(string name ="Default Name", string FilePath="items_0", int cost=0) {
        Name = name;
        spriteFile = FilePath;
        this.price = cost;
    }
}
