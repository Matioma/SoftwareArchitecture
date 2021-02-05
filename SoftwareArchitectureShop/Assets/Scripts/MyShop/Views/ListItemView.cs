using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListItemView : ItemView
{
    [SerializeField] TextMeshProUGUI NameTarget;
    [SerializeField] TextMeshProUGUI priceTarget;
    [SerializeField] TextMeshProUGUI categoryTarget;

    [SerializeField] GameObject highLight; //prefab

    public override void Display()
    {


        NameTarget.text = item.Name;
        priceTarget.text = item.price.ToString();
        categoryTarget.text = item.GetType().ToString();

        if (item.IsSelected)
        {
            highLight.SetActive(true);
        }
    }
}