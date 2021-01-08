using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item
{
    [SerializeField]
    public string Name;
    public string spriteFile;
    public int cost = 0;


    public bool IsSelected {get;set;}= false;

    protected Item(string name ="Default Name", string FilePath="items_0", int cost=0) {
        Name = name;
        spriteFile = FilePath;
        this.cost = cost;
    }
}
