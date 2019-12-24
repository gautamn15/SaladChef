using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemData
{
    public int ItemID;
    public string ItemName;
    public string Description;
    public float Price;
    public int Category;
    public int Store;
}

public class ItemManager : MonoBehaviour
{
    public List<ItemData> _ItemData;

    public ItemData GetItemData(int itemID)
    {
        return _ItemData.Find(x => x.ItemID == itemID);
    }

    public List<ItemData> GetAllItems()
    {
        return _ItemData;
    }
}
