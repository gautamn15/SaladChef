using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiItemData : MonoBehaviour
{
    public ItemData mItemData;
    public Text _ItemName;
    public ItemData mUiItemData;
    public Image _Image;
    public bool mSelected;

    public void SetItemData(ItemData itemData)
    {
        mItemData = itemData;
    }

    public void SetName(string name)
    {
        _ItemName.text = name;
    }

    public void SetColor(Color color)
    {
        _Image.color = color;
    }
}
