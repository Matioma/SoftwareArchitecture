using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPanelView : ItemView
{
    [SerializeField]
    Image iconImage;

    [SerializeField] TextMeshProUGUI NameTarget;
    [SerializeField] TextMeshProUGUI attributes;
    [SerializeField] TextMeshProUGUI enchantements;
    [SerializeField] TextMeshProUGUI description;

    public override void Display()
    {
        NameTarget.text = item.Name;
        attributes.text = item.attributes;

        string enchantementText = "";
        foreach (var enchantment in item.echantements) { enchantementText += enchantment + "\n"; }
        enchantements.text = enchantementText;

        description.text = item.description;
    }
}
