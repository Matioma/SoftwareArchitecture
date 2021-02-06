
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


    IJsonParser<ItemDataFile> parser = new FacadeClass<ItemDataFile>();



    int MaxArmor = 20;
    int minArmor = 1;

    int hpPerRarity = 150;

    int MaxDamage = 20;
    int minDamage = 1;


    int minPriceValue = 1;
    int maxPriceValue = 10;
    int armorPriceMultiplier = 15;
    int weaponPriceMultipler = 20;
    int potionPriceMultiplier = 2;

    

    public Armor CreateArmor()
    {
        ItemDataFile data = parser.ParseJson("itemGeneration/Armors");
        
        //LoadFile
        Armor armor = new Armor("armorObject ", "items_" + random.Next(102, 124), 10);
        armor.Name = data.names[random.Next(0, data.names.Length)];

        armor.description = data.descriptions[random.Next(0, data.descriptions.Length)];
        armor.rarity = CreateItemRarity();

        armor.Price = ((int)armor.rarity+1) * random.Next(minPriceValue, maxPriceValue) * armorPriceMultiplier;
        armor.attributes = random.Next(minArmor, MaxArmor) + " armor";

        for (int i = 0; i < (int)armor.rarity; i++) {
            armor.echantements.Add(data.enchantements[random.Next(data.enchantements.Length)]);
        }
        return armor;
    }

    public Weapon CreateWeapon()
    {

        ItemDataFile data = parser.ParseJson("itemGeneration/Weapons");

        //LoadFile
        Weapon weapon = new Weapon("weaponObject " , "items_" + random.Next(73, 102), 10);
        weapon.Name = data.names[random.Next(0, data.names.Length)];

        weapon.description = data.descriptions[random.Next(0, data.descriptions.Length)];
        weapon.rarity = CreateItemRarity();


        weapon.Price = ((int)weapon.rarity+1) * random.Next(minPriceValue, maxPriceValue) * weaponPriceMultipler;
        weapon.attributes = ((int)weapon.rarity + 1) * random.Next(minDamage,MaxDamage) + " damage";


        for (int i = 0; i < (int)weapon.rarity; i++)
        {
            weapon.echantements.Add(data.enchantements[random.Next(data.enchantements.Length)]);
        }

        return weapon;
    }

    public Potion CreatePotion()
    {
        ItemDataFile data = parser.ParseJson("itemGeneration/Potions");

        Potion potion = new Potion("weaponObject ", "items_" + random.Next(130, 145), 10);
        potion.Name = data.names[random.Next(0, data.names.Length)];

        potion.description = data.descriptions[random.Next(0, data.descriptions.Length)];
        potion.rarity = CreateItemRarity();

        potion.Price = ((int)potion.rarity+1) * random.Next(minPriceValue, maxPriceValue) * potionPriceMultiplier;
        potion.attributes = ((int)potion.rarity + 1) * hpPerRarity + " hp";

        for (int i = 0; i < (int)potion.rarity; i++)
        {
            potion.echantements.Add(data.enchantements[random.Next(data.enchantements.Length)]);
        }

        return potion;
    }


    ItemRarity CreateItemRarity() {
        Type type = typeof(ItemRarity);
        Array values = type.GetEnumValues();
        int index = random.Next(values.Length);

        return (ItemRarity)values.GetValue(index);
    }
}
