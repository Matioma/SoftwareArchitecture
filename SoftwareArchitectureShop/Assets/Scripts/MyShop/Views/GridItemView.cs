using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridItemView : ItemView
{
    [SerializeField]
    Image ItemImage; //Set in Prefab


    [SerializeField]
    GameObject heightLight; //prefab

    public override void Display()
    {
        ItemImage.sprite = this.sprite;
        if (item.IsSelected) {
            heightLight.SetActive(true);
        }
    }
}
