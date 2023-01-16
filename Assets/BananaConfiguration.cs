using System;
using System.Collections;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class BananaConfiguration : MonoBehaviour
{
    public KartRemoteConfig configurator;
    KartRemoteData kartData;
    public TMP_InputField configText;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(DelayOverwriteConfig());
    }

    IEnumerator DelayOverwriteConfig()
    {
        yield return new WaitForSeconds(3f);
        if(PlayerPrefs.HasKey("overwrite_config"))
        {
            configText.text = PlayerPrefs.GetString("overwrite_config");
            Debug.Log("Config text loaded:" + configText.text);
            OverwriteConfig();
        }
    }
    public void OverwriteConfig()
    {
        try
        {
            kartData = JsonConvert.DeserializeObject<KartRemoteData>(configText.text);
 
            configurator.SetDataManually(kartData);
            PlayerPrefs.SetString("overwrite_config", configText.text);
            Debug.Log("New Configuration Accepted.  Saved.");
        }
        catch(Exception e)
        {
            Debug.LogError("There was a problem with the config json" + configText.text + " e:" + e.Message);
        }
    }

    
}