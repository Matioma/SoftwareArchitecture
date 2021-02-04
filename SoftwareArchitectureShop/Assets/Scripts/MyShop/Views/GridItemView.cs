using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridItemView : ItemView
{
    [SerializeField] Image IconImageTarget;
    [SerializeField] TextMeshProUGUI NameTarget;
    [SerializeField] TextMeshProUGUI priceTarget;
    [SerializeField] TextMeshProUGUI categoryTarget;
    [SerializeField] TextMeshProUGUI attributesTarget;
    [SerializeField] TextMeshProUGUI echantementsTarget;
    [SerializeField] TextMeshProUGUI descriptionTarget;
    [SerializeField] TextMeshProUGUI ratityTarget;

    [SerializeField] GameObject highLight; //prefab
    [SerializeField]
    GameObject InfoPanelGameObject;

    public override void Display()
    {
        IconImageTarget.sprite = this.sprite;
        if (item.IsSelected) {
            highLight.SetActive(true);
            InfoPanelGameObject.SetActive(true);
        }
    }
}
