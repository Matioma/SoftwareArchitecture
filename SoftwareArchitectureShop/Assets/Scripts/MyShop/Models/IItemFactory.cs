using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IItemFactory {

    Armor CreateArmor();
    Weapon CreateWeapon();
    Potion CreatePotion();
}