using System.Collections;
using System.Collections.Generic;
using Mozart;
using UnityEngine;

public class KartGameData : MonoBehaviour
{
    public MozartManager manager;
    public TMPro.TextMeshProUGUI balanceLabel;
    // Start is called before the first frame update
    void Start()
    {
        manager.onLoggedInEvent += LoggedIn;
        manager.onUserDataChanged += UserDataChanged;
    }

    void LoggedIn()
    {
        manager.userData.balance = 1000;
        UserDataChanged();
    }

    void UserDataChanged()
    {
        balanceLabel.text = manager.userData.balance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
