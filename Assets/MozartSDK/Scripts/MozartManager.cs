namespace Mozart
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class MozartManager : MonoBehaviour
    {
        public static MozartManager instance;
        public List<NFTItem> storeItems;
        public List<NFTItem> inventoryItems = new List<NFTItem>();
        public string SessionToken = "";
        public MozartUser userData = new MozartUser();
        public WebServices webs;
        public AudioSource chaChing;

        public delegate void ON_LOGIN();
        public ON_LOGIN onLoggedInEvent;

        public delegate void ON_INVENTORY_LOADED();
        public ON_INVENTORY_LOADED onInventoryLoadedEvent;

        public delegate void ON_STORE_LOADED();
        public ON_STORE_LOADED onStoreLoadedEvent;

        public delegate void ON_PURCHASE_COMPLETE();
        public ON_PURCHASE_COMPLETE onPurchaseCompleteEvent;

        public delegate void ON_USER_CHANGE();
        public ON_USER_CHANGE onUserDataChanged;

        public bool IsLoggedIn()
        {
            return SessionToken != "";
        }

        // Start is called before the first frame update
        void Start()
        {
            if (!instance) instance = this;
            UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
        }

        public void SetSessionToken(string sessionToken)
        {
            SessionToken = sessionToken;
            LoadStore();
            LoadInventory();
            if (onLoggedInEvent != null) onLoggedInEvent.Invoke();
        }

        public void SetUserData()
        {
            if (onUserDataChanged != null) onUserDataChanged();
        }

        public void BuyItem(NFTItem item)
        {
            if (inventoryItems.Contains(item)) return;
            if (userData == null || userData.balance < item.price) return;
            userData.balance -= item.price;
            inventoryItems.Add(item);
            chaChing.Play();
            if (onPurchaseCompleteEvent != null) onPurchaseCompleteEvent();
            if (onUserDataChanged != null) onUserDataChanged();
        }

        public NFTItem GetItemByKey(string key)
        {
            foreach(NFTItem item in storeItems)
            {
                if (key == item.itemKey) return item;
            }
            return null;
        }

        public bool UserHasItem(string key)
        {
            foreach (NFTItem item in inventoryItems)
            {
                if (key == item.itemKey) return true;
            }
            return false;
        }

        public void LoadInventory()
        {
            Debug.Log("Inventory Loaded");
            //TODO: Hook up web services
            if (onInventoryLoadedEvent != null) onInventoryLoadedEvent();
        }

        public void LoadStore()
        {
            storeItems = new List<NFTItem>();
            //FAKE DATA FOR DEMO
            storeItems.Add(new NFTItem(){ name = "Beast", price = 125, itemKey = "car_beast" });
            storeItems.Add(new NFTItem(){ name = "Red Dragon", price = 125, itemKey = "car_red_dragon" });
            Debug.Log("Store Loaded");
            //TODO: Hook up web services
            if (onStoreLoadedEvent != null) onStoreLoadedEvent();
        }
    }

}
