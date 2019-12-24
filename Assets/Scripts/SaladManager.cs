using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladManager : MonoBehaviour
{
    public ItemManager _ItemManager;

    public GameObject _TableRed;
    public GameObject _TableBlue;

    public GameObject _VegetableTemplateButton;
    public List<UiItemData> mUiItemDataList = new List<UiItemData>();

    public Dictionary<PlayerA, UiItemData> playerADict = new Dictionary<PlayerA, UiItemData>();
    public Dictionary<PlayerB, UiItemData> playerBDict = new Dictionary<PlayerB, UiItemData>();

    public void Start()
    {
        CreateItems();
    }

    public void CreateItems()
    {
        for (int i = 0; i < _ItemManager._ItemData.Count; ++i)
        {
            GameObject vegetableObject = Instantiate(_VegetableTemplateButton);
            UiItemData uiItemData = vegetableObject.GetComponent<UiItemData>();
            uiItemData.SetName(_ItemManager._ItemData[i].ItemName);
            uiItemData.gameObject.SetActive(true);

            if (i % 2 == 0)
            {
                uiItemData.transform.SetParent(_TableBlue.transform);
            }
            else
            {
                uiItemData.transform.SetParent(_TableRed.transform);
            }

            uiItemData.transform.localScale = Vector3.one;

            mUiItemDataList.Add(uiItemData);
        }
    }

    public void SetSelectedItem(PlayerA player, int itemID)
    {
        UiItemData itemData = mUiItemDataList.Find(x => x.mItemData.ItemID == itemID);
        if(itemData != null && itemData.mSelected == false)
        {
            itemData.mSelected = true;
            itemData.SetColor(Color.blue);
            playerADict.Add(player, itemData);
        }
    }

    public void SetSelectedItem(PlayerB player, int itemID)
    {
        UiItemData itemData = mUiItemDataList.Find(x => x.mItemData.ItemID == itemID);
        if (itemData != null && itemData.mSelected == false)
        {
            itemData.mSelected = true;
            itemData.SetColor(Color.green);
            playerBDict.Add(player, itemData);
        }
    }
}
