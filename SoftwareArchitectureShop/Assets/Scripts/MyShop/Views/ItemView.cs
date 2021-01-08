using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public abstract class ItemView : MonoBehaviour
{
    [SerializeField]
    protected Item item;
    [SerializeField]
    SpriteAtlas spriteAtlas; // Set in prefab

    protected Sprite sprite; //Used For rendering


    public Item GetItemData()=>item;

    public void SetItemData(Item item)
    {
        this.item = item;
        sprite = spriteAtlas.GetSprite(item.spriteFile);
    }

    public abstract void Display();
}
