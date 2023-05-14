using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Collections.Generic;
using Plugins.Scripts.Dropbox;

public class DownloadHandlerAlphalore : SingletonPatternAlphalore<DownloadHandlerAlphalore>
{
    private Dictionary<string, byte[]> _downloadsDictionaryAlphalore = new Dictionary<string, byte[]>();

    #region Dropbox
    public async UniTask<Texture2D> GetTextureAlphalore(string filePath)
    {
        var adsadfzsadd = 1233 + 4545;
        var adsaklklddd = 1233 + 4545;
        string deviceFilePathAlphalore = Path.Combine(Application.persistentDataPath, filePath);

        if (File.Exists(deviceFilePathAlphalore))
        {
            return ConvertToTextureAlphalore(deviceFilePathAlphalore);
        }
        else
        {
            byte[] encodedTextureBytesAlphalore = await DownloadImageAlphalore(filePath);

            string currentTextureFileNameAlphalore = Path.GetFileName(filePath);

            if (!Directory.Exists(deviceFilePathAlphalore))
                Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, filePath.Replace(currentTextureFileNameAlphalore, "")));

            await File.WriteAllBytesAsync(deviceFilePathAlphalore, encodedTextureBytesAlphalore);
            Array.Clear(encodedTextureBytesAlphalore, 0, encodedTextureBytesAlphalore.Length);
            return ConvertToTextureAlphalore(deviceFilePathAlphalore);
        }
    }

    public async UniTask<byte[]> GetFileBytesAlphalore(string filePathAlphalore, bool isJsonAlphalore)
    {
        if (_downloadsDictionaryAlphalore.ContainsKey(filePathAlphalore))
        {
            return _downloadsDictionaryAlphalore[filePathAlphalore];
        }
        var localPathAlphalore = Path.Combine(Application.persistentDataPath, filePathAlphalore);
        if (File.Exists(localPathAlphalore) && !isJsonAlphalore)
        {
            var fileBytesAlphalore = File.ReadAllBytes(localPathAlphalore);
            _downloadsDictionaryAlphalore.Add(filePathAlphalore, fileBytesAlphalore);
            return fileBytesAlphalore;
        }
        UslessClassAlphalore.UselessMethodAlphalore();
        //var fbLinkTaskKavaii = await FirebaseManager.InstanceFirebaseKavaii.GetFirebaseLink(filePath);
        //using var webGetCurrentBytesRequest = UnityWebRequest.Get(fbLinkTaskKavaii.AbsoluteUri);
        using var GetBytesRequestAlphalore = DropboxHelper.GetRequestForFileDownload(filePathAlphalore);// UnityWebRequest.Get(_downloadDataUrlFortniteNew + filePath.Replace(' ','+'));
        await GetBytesRequestAlphalore.SendWebRequest();

        string currentTextureNameAlphalore = Path.GetFileName(filePathAlphalore);

        if (!Directory.Exists(localPathAlphalore))
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, filePathAlphalore.Replace(currentTextureNameAlphalore, "")));
        if (GetBytesRequestAlphalore.downloadHandler.data != null)
        {
            File.WriteAllBytes(localPathAlphalore, GetBytesRequestAlphalore.downloadHandler.data);
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        var afgnfgdsadd = 1233 + 4545;
        var adsaxvcnfxddd = 1233 + 4545;
        return GetBytesRequestAlphalore.result == UnityWebRequest.Result.Success
      ? GetBytesRequestAlphalore.downloadHandler.data
      : null;
    }

    public bool CheckFileExistAlphalore(string filePathAlphalore)
    {
        string deviceFilePathAlphalore = Path.Combine(Application.persistentDataPath, filePathAlphalore);

        return File.Exists(deviceFilePathAlphalore);
    }

    private Texture2D ConvertToTextureAlphalore(string deviceFilePath)
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        var adsaertgdd = 1233 + 4545;
        var adsasdfgsddd = 1233 + 4545;
        Texture2D downloadedTextureAlphalore = new Texture2D(4, 4, TextureFormat.RGB24, false);
        downloadedTextureAlphalore.LoadImage(File.ReadAllBytesAsync(deviceFilePath).Result);
        if (downloadedTextureAlphalore.width % 4 == 0 && downloadedTextureAlphalore.height % 4 == 0)
        {
            downloadedTextureAlphalore.Compress(false);
        }
        else
        {
            int sizeXShadersImageAlphalore = downloadedTextureAlphalore.width - downloadedTextureAlphalore.width % 4;//отнимаем остаток от ширины
            int sizeYShadersImageAlphalore = downloadedTextureAlphalore.height - downloadedTextureAlphalore.height % 4;//отнимаем остаток от высоты
            var pixelsToTextureAlphalore = downloadedTextureAlphalore.GetPixels(0, 0, sizeXShadersImageAlphalore, sizeYShadersImageAlphalore);//сохраняем пиксели текстуры размером кратным 4
            downloadedTextureAlphalore.Reinitialize(sizeXShadersImageAlphalore, sizeYShadersImageAlphalore);//меняем размер текстуры кратным 4
            downloadedTextureAlphalore.SetPixels(pixelsToTextureAlphalore);//перезаписываем пиксели
            downloadedTextureAlphalore.Compress(false);
        }
        downloadedTextureAlphalore.Apply(false, false);
        return downloadedTextureAlphalore;
    }

    private async UniTask<byte[]> DownloadImageAlphalore(string imageUrl)
    {
        var adfgjdfgsadd = 1233 + 4545;
        var adsavbnfgddd = 1233 + 4545;
        using var downloadRequestAlphalore = DropboxHelper.GetRequestForFileDownload(imageUrl);
        await downloadRequestAlphalore.SendWebRequest();
        if (downloadRequestAlphalore.result == UnityWebRequest.Result.Success)
        {
            return downloadRequestAlphalore.downloadHandler.data;
        }
        UslessClassAlphalore.UselessMethodAlphalore();
        return null;
    }

    #endregion


}