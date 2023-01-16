using System;
using System.Collections;
using System.Collections.Generic;
using Mozart;
using UnityEngine;

[Serializable]
public class KartRemoteData
{
    public string api_url = "";
    public string dashboard_url = "";
    public string token_id = "";
    public string game_id = "";
    public string car_1 = "";
    public string car_2 = "";
    public string car_3 = "";
}


public class KartRemoteConfig : MozartBehaviorBase
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("VERSION  :" + Application.version);
        
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            GetManager().onReady += TriggerLoadServerConfig;
            Application.ExternalCall("PlayerLoaded", null);
        }
        else
        {
            TriggerLoadServerConfig();
        }
    }

    void TriggerLoadServerConfig()
    {
        base.GetManager().webs.GetRequest<KartRemoteData>(base.GetManager().configURL, (KartRemoteData data) =>
        {
            base.GetManager().settings.apiBaseUrl = data.api_url;
            base.GetManager().settings.GameCurrencyIdentifier = data.token_id;
            base.GetManager().settings.GameIdentifier = data.game_id;
            base.GetManager().settings.DashboardUrl = data.dashboard_url;
        }, true);
    }

    public void SetDataManually(KartRemoteData data)
    {
        base.GetManager().settings.apiBaseUrl = data.api_url;
        base.GetManager().settings.GameCurrencyIdentifier = data.token_id;
        base.GetManager().settings.GameIdentifier = data.game_id;
        base.GetManager().settings.DashboardUrl = data.dashboard_url;
    }
}
