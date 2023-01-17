namespace Mozart
{ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.UI;

    public class MozartStoreInfoPanelController : MozartNFTInfoPanelController
{
        public Button buyButton;
        public Text buyButtonText;
        [SerializeField]
        public void BuySelectedItem()
        {
            buyButton.interactable = false;
            GetManager().BuyItem(this.currentItem.itemTemplateId);
        }

        public override void SetData(NFTItem item)
        {
            buyButton.interactable = true;
            buyButtonText.text = "Buy for " + item.price;
            if (GetManager().GetItemIsOwnedByName(item.name))
            {
                buyButton.interactable = false;
                buyButtonText.text = "Already Owned";
            }
            if(GetManager().userData.GetBalance() < int.Parse(item.price))
            {
                buyButton.interactable = false;
                buyButtonText.text = "Not enough Money";
            }
            
            currentItem = item;
            nameText.text = item.name;
            descriptionText.text = item.description;
        }
    }
}