namespace Mozart
{ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozartStoreInfoPanelController : MozartNFTInfoPanelController
{
        [SerializeField]
        public void BuySelectedItem()
        { 
            GetManager().BuyItem(this.currentItem.itemTemplateId);
        }

        public override void SetData(NFTItem item)
        {
            currentItem = item;
            nameText.text = item.name + " $" + item.price.ToString();
            descriptionText.text = item.description;
        }
    }
}