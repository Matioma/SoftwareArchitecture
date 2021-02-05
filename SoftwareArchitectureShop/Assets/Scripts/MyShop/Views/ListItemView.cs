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

        //IconImageTarget.sprite = this.sprite;
        //NameTarget.text = item.Name;
        //priceTarget.text = item.price.ToString();
        //categoryTarget.text = 
        //attributesTarget.text = item.attributes;

        //string enchantementText = "";
        //foreach (var enchantment in item.echantements) { enchantementText += enchantment + "\n"; }

        ////Debug.LogWarning(enchantementText);
        //echantementsTarget.text = enchantementText;
        //descriptionTarget.text = item.description;
        //ratityTarget.text = item.rarity.ToString();

        if (item.IsSelected)
        {
            highLight.SetActive(true);
            //InfoPanelGameObject.SetActive(true);
        }
    }
}