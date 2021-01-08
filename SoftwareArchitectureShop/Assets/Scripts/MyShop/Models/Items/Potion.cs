using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    public Potion(string name = "Default Name", string FilePath = "items_0", int cost = 0) : base(name, FilePath, cost)
    {
    }
}
