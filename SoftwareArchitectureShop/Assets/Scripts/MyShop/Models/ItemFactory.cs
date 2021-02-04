
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemDataFile {
    public string[] names;
    public string[] descriptions;
    public string[] enchantements;
}


public class ItemFactory : IItemFactory
{
    System.Random random = new System.Random();
    TextAsset LoadFile(string Path)
    {
        return Resources.Load<TextAsset>(Path);
    }

    public Armor CreateArmor()
    {
        ItemDataFile data = JsonUtility.FromJson<ItemDataFile>(LoadFile("itemGeneration/Armors").text);

        
        //LoadFile
        Armor armor = new Armor("armorObject " + random.Next(0,1000), "items_" + random.Next(102, 124), 10);
        armor.Name = data.names[random.Next(0, data.names.Length)];

        armor.description = data.descriptions[random.Next(0, data.descriptions.Length)];
        armor.rarity = CreateItemRarity();

        armor.attributes = random.Next(1, 20) + " armor";

        //if (random.Next(0, 2)==0) {
            armor.echantements.Add(data.enchantements[random.Next(data.enchantements.Length)]);
        Debug.Log(armor.echantements[0]);
        //}


        return armor;
    }

    public Weapon CreateWeapon()
    {
        //Weapon weapon = new Weapon("WeaponObject " + random.Next(0, 1000), "items_" + random.Next(73, 102), 10);
        ItemDataFile data = JsonUtility.FromJson<ItemDataFile>(LoadFile("itemGeneration/Weapons").text);

        //LoadFile
        Weapon weapon = new Weapon("weaponObject " + random.Next(0, 1000), "items_" + random.Next(73, 102), 10);
        weapon.Name = data.names[random.Next(0, data.names.Length)];

        weapon.description = data.descriptions[random.Next(0, data.descriptions.Length)];
        weapon.rarity = CreateItemRarity();


        return weapon;
    }

    public Potion CreatePotion()
    {
        ItemDataFile data = JsonUtility.FromJson<ItemDataFile>(LoadFile("itemGeneration/Potions").text);

        Potion potion = new Potion("weaponObject " + random.Next(0, 1000), "items_" + random.Next(130, 145), 10);
        potion.Name = data.names[random.Next(0, data.names.Length)];

        potion.description = data.descriptions[random.Next(0, data.descriptions.Length)];
        potion.rarity = CreateItemRarity();

        return potion;
    }


    ItemRarity CreateItemRarity() {
        Type type = typeof(ItemRarity);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);

        return (ItemRarity)values.GetValue(index);
    }

    
}
