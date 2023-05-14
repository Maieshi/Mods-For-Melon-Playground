using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Plugins.Scripts.Dropbox
{
    public static class DropboxHelper
    {
        // paste from dropbox console
        private const string AppKey = "7wgf0j06q0htx6q";
        private const string AppSecret = "weqknqx7q1dvpkv";

#if UNITY_EDITOR
        // paste auth code from your browser, or given from production department, here. Only valid for about 10 minutes.
        // You can remove it after getting refreshToken
        private const string AuthCode = "iRCN6ym2MLYAAAAAAAAAHU5RkOSnLq7cLEGs_GZj9YE";
#endif

        // paste from GetRefreshToken() result, value of "refresh_token"
        private const string RefreshToken = "SdbTD_dspg8AAAAAAAAAAVcjsqY-Qzpru6F8I__5domAjhBUT8V1cAQdjHs9k3w8";


        private static string _tempRuntimeToken = null;

#if UNITY_EDITOR
        // First, call this method to get an authCode, then paste it in the appropriate field above.
        public static void GetAuthCode()
        {
            var url = $"https://www.dropbox.com/oauth2/authorize?client_id={AppKey}&response_type=code&token_access_type=offline";
            Application.OpenURL(url);
        }

        // After you have pasted an AuthCode, call this method to get refreshToken.
        public static async void GetRefreshToken()
        {
            Debug.Log("Requesting refreshToken...");

            var form = new WWWForm();
            form.AddField("code", AuthCode);
            form.AddField("grant_type", "authorization_code");

            var base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{AppKey}:{AppSecret}"));

            using var request = UnityWebRequest.Post("https://api.dropbox.com/oauth2/token", form);
            request.SetRequestHeader("Authorization", $"Basic {base64Authorization}");

            var sendRequest = request.SendWebRequest();

            while (!sendRequest.isDone)
            {
                await Task.Yield();
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                Debug.LogError(request.downloadHandler.text);
                return;
            }

            var parsedAnswer = JObject.Parse(request.downloadHandler.text);
            var refreshTokenString = parsedAnswer["refresh_token"]?.Value<string>();

            Debug.Log("Copy this string to RefreshToken: " + refreshTokenString);
        }
#endif

        /// <summary>
        /// Call initialization before you start download any files and await it's completion.
        /// To wait inside a coroutine you can use:
        /// var task = DropboxHelper.Initialize();
        /// yield return new WaitUntil(() => task.IsCompleted);
        /// </summary>
        public static async Task Initialize()
        {
            if (string.IsNullOrEmpty(RefreshToken))
            {
                Debug.LogError("refreshToken should be defined before runtime");
            }

            var form = new WWWForm();
            form.AddField("grant_type", "refresh_token");
            form.AddField("refresh_token", RefreshToken);

            var base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{AppKey}:{AppSecret}"));

            using var request = UnityWebRequest.Post("https://api.dropbox.com/oauth2/token", form);
            request.SetRequestHeader("Authorization", $"Basic {base64Authorization}");

            var sendRequest = request.SendWebRequest();

            while (!sendRequest.isDone)
            {
                await Task.Yield();
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                Debug.LogError(request.downloadHandler.text);
            }

            // Debug.Log("Success! Full message from dropbox: " + request.downloadHandler.text);

            var data = JObject.Parse(request.downloadHandler.text);
            _tempRuntimeToken = data["access_token"]?.Value<string>();

            Debug.Log("Token: " + _tempRuntimeToken);
        }

        /// <summary>
        /// Creating a request for file download.
        /// To wait inside a coroutine you can use:
        /// var task = DropboxHelper.GetRequestForFileDownload();
        /// yield return new WaitUntil(() => task.IsCompleted);
        /// </summary>
        /// <param name="relativePathToFile">Pass a relative path from a root folder. Example: "images/image1"</param>
        /// <returns>WebRequest that you should send and then process it's result</returns>
        public static UnityWebRequest GetRequestForFileDownload(string relativePathToFile)
        {
            var request = UnityWebRequest.Get("https://content.dropboxapi.com/2/files/download");
            request.SetRequestHeader("Authorization", $"Bearer {_tempRuntimeToken}");
            request.SetRequestHeader("Dropbox-API-Arg", $"{{\"path\": \"/{relativePathToFile}\"}}");
            return request;
        }
    }
}