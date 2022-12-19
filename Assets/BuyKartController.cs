using System.Collections;
using System.Collections.Generic;
using Mozart;
using UnityEngine;
using UnityEngine.UI;

public class BuyKartController : MozartBehaviorBase
{
    public string itemKey;
    public Image carImage;
    public GameObject lockOverlay;
    public NFTItem item;
    public bool isLocked = false;
    public TMPro.TextMeshProUGUI priceLabel;

    public void Awake()
    {
        GetManager().onPurchaseCompleteEvent += () =>
        {
            DrawButtonState();
        };
    }

    public void OnEnable()
    {
        item = GetManager().GetItemByItemName(itemKey);
        DrawButtonState();
    }

    public void DrawButtonState()
    {
        priceLabel.text = item.price;
        isLocked = !GetManager().GetItemIsOwnedByName(itemKey);
        //carImage.sprite = Resources.Load<Sprite>(itemKey);
        lockOverlay.SetActive(isLocked);
        GetComponent<Button>().interactable = !isLocked;
    }

    public void BuyItem()
    {
        if(GetManager().userData.GetBalance() > int.Parse(item.price))
        {
            GetManager().BuyItem(item.itemTemplateId);
        }
    }
}
