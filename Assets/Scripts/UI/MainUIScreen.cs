using System.Collections;
using System.Collections.Generic;
using Mozart;
using UnityEngine;
using UnityEngine.UI;

public class MainUIScreen : MonoBehaviour
{
    public MozartManager mozartManager;
    public Button PlayButton;
    public Button StoreButton;
    public Button InventoryButton;
    public GameObject CurrencyDisplay;
    public GameObject MozartLoginButton;
    void Awake()
    {
        UIScreen.Focus(GetComponent<UIScreen>());
        StoreButton.interactable = false;
        PlayButton.interactable = false;
        InventoryButton.interactable = false;
        mozartManager.onLoggedInEvent += LoggedIn;
    }

    public void LoggedIn()
    {
        PlayButton.interactable = true;
        StoreButton.interactable = true;
        InventoryButton.interactable = true;
        CurrencyDisplay.SetActive(true);
        MozartLoginButton.SetActive(false);
    }
}
