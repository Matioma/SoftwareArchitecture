using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : IItemFactory
{
    public Armor CreateArmor()
    {
        Armor armor = new Armor("armorObject " + Random.Range(0, 1000), "items_" + Random.Range(73, 102));
        return armor;
    }

    public Potion CreatePotion()
    {
        Potion potion = new Potion("potionObject " + Random.Range(0, 1000), "items_" + Random.Range(130, 145));
        return potion;
    }

    public Weapon CreateWeapon()
    {
        Weapon weapon = new Weapon("WeaponObject " + Random.Range(0, 1000), "items_" + Random.Range(102, 124));
        return weapon;
    }
}
