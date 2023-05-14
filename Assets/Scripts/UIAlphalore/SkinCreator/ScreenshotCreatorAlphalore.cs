using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IOSBridge;
using System.IO;
public class ScreenshotCreatorAlphalore : SingletonPatternAlphalore<ScreenshotCreatorAlphalore>
{
    [SerializeField] private Camera _itemCameraAlphalore;

    [SerializeField] private Camera _skinMakerCameraAlphalore;

    [SerializeField] private Transform _itemsParentAlphalore;

    public Texture2D GetItemPreviewAlphalore(GameObject modelAlphalore)
    {
        Transform itemTransformAlphalore = Instantiate(modelAlphalore, _itemsParentAlphalore.position, Quaternion.Euler(0, 0, 0), _itemsParentAlphalore).transform;
        itemTransformAlphalore.localPosition = Vector3.zero;
        RenderTexture ItemTextureAlphalore = new RenderTexture(Screen.width, Screen.height, 16);
        _itemCameraAlphalore.targetTexture = ItemTextureAlphalore;
        RenderTexture.active = ItemTextureAlphalore;
        _itemCameraAlphalore.Render();
        Texture2D renderedTextureAlphalore = new Texture2D(Screen.width, Screen.height);
        renderedTextureAlphalore.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;
        _itemCameraAlphalore.targetTexture = null;
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        Destroy(itemTransformAlphalore.gameObject);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        //Destroy(itemTransformAlphalore.gameObject);
        return renderedTextureAlphalore;
        // byte[] byteArrayOPT = renderedTextureOPT.EncodeToPNG();
        // await File.WriteAllBytesAsync(savePathOPT, byteArrayOPT);
        // Destroy(renderedTextureOPT);
        // Destroy(ItemTextureAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();

    }

    public async void GetScreenShotAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        string screenshotPathAlphalore = GetScreenshotName();
        // Debug.Log(screenshotPathAlphalore);
        RenderTexture screenTextureAlphalore = new RenderTexture(Screen.width, Screen.height, 16);
        _skinMakerCameraAlphalore.targetTexture = screenTextureAlphalore;
        RenderTexture.active = screenTextureAlphalore;
        _skinMakerCameraAlphalore.Render();
        Texture2D renderedTextureAlphalore = new Texture2D(Screen.width, Screen.height);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        renderedTextureAlphalore.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        _skinMakerCameraAlphalore.targetTexture = null;
        byte[] byteArrayAlphalore = renderedTextureAlphalore.EncodeToPNG();
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        await File.WriteAllBytesAsync(screenshotPathAlphalore, byteArrayAlphalore);
        IOStoUnityBridge.SaveImageToAlbum(screenshotPathAlphalore);

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        int asddvfkdhjk = 123541;
    }

    private string GetScreenshotName()
    {
        for (int i = 0; i < 1000; i++)
        {
            string pathAlphalore = Application.persistentDataPath + "/screenshotAlphalore".Replace("Alphalore", "") + i + ".pngAlphalore".Replace("Alphalore", "");
            if (!File.Exists(pathAlphalore)) return pathAlphalore;
        }
        return Application.persistentDataPath + Path.GetRandomFileName() + "/screenshot.pngAlphalore".Replace("Alphalore", "");
    }

}
