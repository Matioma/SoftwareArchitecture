using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public Armor(string name = "Default Name", string FilePath = "items_0", int cost = 0):base(name, FilePath, cost)
    { 
    }

    public override void  Upgrade()
    {
        base.Upgrade();

        FacadeClass<ItemDataFile> facadeClass = new FacadeClass<ItemDataFile>();
        ItemDataFile data = facadeClass.ParseJson("itemGeneration/Armors");
        echantements.Add(data.enchantements[Random.Range(0,data.enchantements.Length)]);
    }
}
