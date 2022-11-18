using System.Collections;
using System.Collections.Generic;
using Mozart;
using UnityEngine;
using UnityEngine.UI;

public class MainUIScreen : MonoBehaviour
{
    public MozartManager mozartManager;
    public Button PlayButton;
    public GameObject CurrencyDisplay;
    public GameObject MozartLoginButton;
    void Awake()
    {
        UIScreen.Focus(GetComponent<UIScreen>());
        mozartManager.onLoggedInEvent += LoggedIn;
    }

    public void LoggedIn()
    {
        PlayButton.interactable = true;
        CurrencyDisplay.SetActive(true);
        MozartLoginButton.SetActive(false);
    }
}
