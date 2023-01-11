﻿namespace Mozart
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Settings", menuName = "MozartSDK/CreateSettings", order = 1)]
    public class SettingsTemplate : ScriptableObject
    {
        public string DashboardUrl = "https://testnet-dashboard.mozart.xyz";
        public string GameIdentifier;
        public string GameCurrencyIdentifier;
        public bool logging = false;
        public string apiBaseUrl = "https://staging-api-ij1y.onrender.com";
        public void Log(string message)
        {
            if (logging) Debug.Log(message);
        }

        public void Warn(string message)
        {
            if (logging) Debug.LogWarning(message);
        }

        public void Error(string message)
        {
            if (logging) Debug.LogError(message);
        }
    }
}