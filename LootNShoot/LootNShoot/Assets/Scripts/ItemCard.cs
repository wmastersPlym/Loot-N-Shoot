using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCard : MonoBehaviour
{

    public Item item;

    public Text quantityText;

    public void CreateCard(Item item)
    {
        this.item = item;
        updateQuantityText();
        loadImage();
    }

    public void loadImage()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("ItemSprites/" + item.id);
    }

    void updateQuantityText()
    {
        if(item != null)
        {
            quantityText.text = (item.quantity > 1 ? "" + item.quantity : "");
        }
    }

}
