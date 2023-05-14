using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.IO;
using IOSBridge;
public class DownloadButtonAlphalore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _buttonTextAlphalore;

    [HideInInspector] public string _archiveAlphalore;

    [SerializeField] public Button _dowloadButtonAlphalore;

    [SerializeField] public Button _returnButtonAlphalore;

    private bool _isLoadingAlphalore;

    private bool _isArchiveExistAlphalore { get { return DownloadHandlerAlphalore.Instance.CheckFileExistAlphalore(_archiveAlphalore); } }

    private async void OnEnable()
    {
        await Task.Delay(100);
        if (!_isArchiveExistAlphalore)
            _buttonTextAlphalore.text = "DownloadAlphalore".Replace("Alphalore", "");
        else
            _buttonTextAlphalore.text = "ImportAlphalore".Replace("Alphalore", "");
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public async void DowloadAlphalore()
    {

        if (!_isArchiveExistAlphalore)
        {
            _isLoadingAlphalore = true;
            LoadingAnimationAlphalore();
            await DownloadHandlerAlphalore.Instance.GetFileBytesAlphalore(_archiveAlphalore, false);

            _isLoadingAlphalore = false;
        }
        else
        {
            IOStoUnityBridge.InitWithActivity(Path.Combine(Application.persistentDataPath, _archiveAlphalore));
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private async void LoadingAnimationAlphalore()
    {
        _dowloadButtonAlphalore.interactable = false;
        _returnButtonAlphalore.interactable = false;

        while (_isLoadingAlphalore)
        {
            _buttonTextAlphalore.text = "Loading.Alphalore".Replace("Alphalore", "");
            await Task.Delay(500);
            _buttonTextAlphalore.text = "Loading..Alphalore".Replace("Alphalore", "");
            await Task.Delay(500);
            _buttonTextAlphalore.text = "Loading...Alphalore".Replace("Alphalore", "");
            await Task.Delay(500);

        }
        UslessClassAlphalore.UselessMethodAlphalore();
        await Task.Delay(1000);
        _buttonTextAlphalore.text = "ImportAlphalore".Replace("Alphalore", "");
        _dowloadButtonAlphalore.interactable = true;
        _returnButtonAlphalore.interactable = true;
        UslessClassAlphalore.UselessMethodAlphalore();
    }
}
