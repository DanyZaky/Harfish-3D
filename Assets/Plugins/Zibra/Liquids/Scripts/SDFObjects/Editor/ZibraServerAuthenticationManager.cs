﻿#if ZIBRA_LIQUID_PAID_VERSION && UNITY_EDITOR

using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

namespace com.zibra.liquid.Editor.SDFObjects
{
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    public class ZibraServerAuthenticationManager
    {
        // TODO switch from staging server address
        private const string BASE_URL = "https://generation.zibra.ai/";
        private string UserHardwareID = "";
        private string UserID = "";
        private UnityWebRequestAsyncOperation request;

        public string PluginLicenseKey = "";
        private bool IsLicenseKeyValid = false;
        public string GenerationURL = "";
        public bool bNeedRefresh = false;

        public enum Status
        {
            OK,
            KeyValidationInProgress,
            NetworkError,
            NotRegistered,
            NotInitialized,
        }

        Status CurrentStatus = Status.NotInitialized;

        public Status GetStatus()
        {
            if (CurrentStatus == Status.NotInitialized)
            {
                Initialize();
            }

            return CurrentStatus;
        }

        public string GetErrorMessage()
        {
            switch (CurrentStatus)
            {
            case Status.KeyValidationInProgress:
                return "License key validation in progress. Please wait.";
            case Status.NetworkError:
                return "Network error. Please try again later.";
            case Status.NotRegistered:
                return "Product is not registered.";
            default:
                return "";
            }
        }

        private class LicenseKeyResponse
        {
            public string api_key;
        }

        private static ZibraServerAuthenticationManager instance = null;

        public string GetUserID()
        {
            if (UserID == "")
            {
                CollectUserInfo();
            }

            return UserID;
        }

        [RuntimeInitializeOnLoadMethod]
        public static ZibraServerAuthenticationManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ZibraServerAuthenticationManager();
                instance.Initialize();
            }

            return instance;
        }

        private string GetEditorPrefsLicenceKey()
        {
            if (EditorPrefs.HasKey("ZibraLiquidLicenceKey"))
            {
                return EditorPrefs.GetString("ZibraLiquidLicenceKey");
            }

            return "";
        }

        private string GetValidationURL(string key)
        {
            return BASE_URL + "api/apiKey?api_key=" + key + "&type=validation";
        }

        private string GetRenewalKeyURL()
        {
            return BASE_URL + "api/apiKey?user_id=" + UserID + "&type=renew";
        }

        void SendRequest(string key)
        {
            string requestURL;
            if (key != "")
            {
                // check if key is valid
                requestURL = GetValidationURL(key);
            }
            else if (UserID != "")
            {
                // request new key based on User and Hardware ID
                requestURL = GetRenewalKeyURL();
            }
            else
            {
                CurrentStatus = Status.NotRegistered;
                return;
            }

            request = UnityWebRequest.Get(requestURL).SendWebRequest();
            request.completed += UpdateKeyRequest;
            CurrentStatus = Status.KeyValidationInProgress;
        }

        // Pass true when Initialize is called as a result of user interaction
        public void Initialize()
        {
            if (CurrentStatus != Status.OK && CurrentStatus != Status.KeyValidationInProgress)
            {
                // Get user ID
                CollectUserInfo();

                PluginLicenseKey = GetEditorPrefsLicenceKey();
                SendRequest(PluginLicenseKey);
            }
        }

        void RefreshAboutTab()
        {
            if (!bNeedRefresh)
                bNeedRefresh = true;
        }

        public void UpdateKeyRequest(AsyncOperation obj)
        {
            if (IsLicenseKeyValid)
                return;

            if (request.isDone)
            {
                var result = request.webRequest.downloadHandler.text;
#if UNITY_2020_2_OR_NEWER
                if (result != null && request.webRequest.result == UnityWebRequest.Result.Success)
#else
                if (result != null && !request.webRequest.isHttpError && !request.webRequest.isNetworkError)
#endif
                {
                    PluginLicenseKey = JsonUtility.FromJson<LicenseKeyResponse>(result).api_key;
                    if (PluginLicenseKey != "")
                    {
                        CurrentStatus = Status.OK;
                        IsLicenseKeyValid = true;
                        SetLicenceKey(PluginLicenseKey);
                        // populate server request URL if everything is fine
                        GenerationURL = CreateGenerationRequestURL();
                    }
                    else
                    {
                        CurrentStatus = Status.NotRegistered;
                    }
                    RefreshAboutTab();
                }
#if UNITY_2020_2_OR_NEWER
                else if (request.webRequest.result != UnityWebRequest.Result.Success)
#else
                else if (request.webRequest.isHttpError || request.webRequest.isNetworkError)
#endif
                {
                    CurrentStatus = Status.NetworkError;
                    Debug.Log(request.webRequest.error);
                }
            }
            return;
        }

        public void RegisterKey(string key)
        {
            IsLicenseKeyValid = false;
            SendRequest(key);
        }

        private void SetLicenceKey(string key)
        {
            EditorPrefs.SetString("ZibraLiquidLicenceKey", key);
        }

        public void CollectUserInfo()
        {
            UserHardwareID = SystemInfo.deviceUniqueIdentifier;

            var assembly = Assembly.GetAssembly(typeof(UnityEditor.EditorWindow));
            var uc = assembly.CreateInstance("UnityEditor.Connect.UnityConnect", false,
                                             BindingFlags.NonPublic | BindingFlags.Instance, null, null, null, null);
            // Cache type of UnityConnect.
            if (uc == null)
            {
                return;
            }

            var t = uc.GetType();
            // Get user info object from UnityConnect.
            var userInfo = t.GetProperty("userInfo")?.GetValue(uc, null);
            // Retrieve user id from user info.
            if (userInfo == null)
            {
                return;
            }

            var userInfoType = userInfo.GetType();
            var isValid = userInfoType.GetProperty("valid");
            if (isValid == null || isValid.GetValue(userInfo, null).Equals(false))
            {
                return;
            }

            UserID = userInfoType.GetProperty("userId")?.GetValue(userInfo, null) as string;
            if (UserID == "")
            {
                return;
            }
        }

        private string CreateGenerationRequestURL()
        {
            if (GenerationURL != "")
                return GenerationURL;

            GenerationURL = BASE_URL + "api/unity/compute?";

            if (UserID != "")
            {
                GenerationURL += "&user_id=" + UserID;
            }

            if (UserHardwareID != "")
            {
                GenerationURL += "&hardware_id=" + UserHardwareID;
            }

            if (PluginLicenseKey != "")
            {
                GenerationURL += "&api_key=" + PluginLicenseKey;
            }

            return GenerationURL;
        }
    }
}

#endif
