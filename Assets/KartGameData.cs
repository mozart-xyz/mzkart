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
        balanceLabel.text = manager.userData.extraData.balances[0].GetBalance().ToString();
    }
}
