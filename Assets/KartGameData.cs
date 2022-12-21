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
        manager.onStoreLoadedEvent -= UserDataChanged;
        manager.onStoreLoadedEvent += UserDataChanged;
    }

    void UserDataChanged()
    {
        if(manager.userData != null && manager.userData.extraData != null && manager.userData.extraData.balances != null && manager.userData.extraData.balances.Count > 0)
        {
            balanceLabel.text = manager.userData.GetBalance().ToString();
        }
    }
}
