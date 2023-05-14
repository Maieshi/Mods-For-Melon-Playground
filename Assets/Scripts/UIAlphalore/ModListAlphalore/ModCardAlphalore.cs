using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
public class ModCardAlphalore : MonoBehaviour
{
    [SerializeField] private RawImage _modImageAlphalore;
    [SerializeField] private Texture2D _deafaultTextureAlphalore;
    [SerializeField] private TextMeshProUGUI _modTextAlphalore;
    [SerializeField] private TextMeshProUGUI _modDescriptionAlphalore;
    [SerializeField] private GameObject _loadingAlphalore;
    [SerializeField] private Toggle _likeToggleAlphalore;

    private Action OnCancelLoadingAlphalore;

    // string f = 133;
    private bool isLikedAlphalore = false;
    // delegate void CancellationHandler();

    public CardDataAlphalore _itemDataAlphalore { get; private set; }

    public async void SetDataAlphalore(CardDataAlphalore dataAlphaloreAlphalore)
    {
        CancellationTokenSource sourceAlphalore = new CancellationTokenSource();
        CancellationToken tokenAlphalore = sourceAlphalore.Token;
        void CancelSource()
        {
            sourceAlphalore.Cancel();
        }
        OnCancelLoadingAlphalore += CancelSource;
        try
        {
            await SetDataAsyncAlphalore(sourceAlphalore.Token, dataAlphaloreAlphalore);
        }
        catch (OperationCanceledException)
        {
            OnCancelLoadingAlphalore -= CancelSource;
        }
        finally
        {
            sourceAlphalore = null;
        }
        OnCancelLoadingAlphalore -= CancelSource;
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private async Task SetDataAsyncAlphalore(CancellationToken tokenAlphalore1, CardDataAlphalore dataAlphalore1)
    {

        _likeToggleAlphalore.interactable = false;
        _loadingAlphalore.SetActive(true);
        _modImageAlphalore.texture = _deafaultTextureAlphalore;
        _itemDataAlphalore = dataAlphalore1;
        _modTextAlphalore.text = dataAlphalore1.CardNameAlphalore;
        _modDescriptionAlphalore.text = dataAlphalore1.CardDestriptionAlphalore;
        _likeToggleAlphalore.isOn = (PlayerPrefs.HasKey(_itemDataAlphalore.CardImageAlphalore) && PlayerPrefs.GetInt(_itemDataAlphalore.CardImageAlphalore) == 1) ? true : false;
        Texture2D texAlphalore = await DownloadHandlerAlphalore.Instance.GetTextureAlphalore(dataAlphalore1.CardImageAlphalore);
        if (!dataAlphalore1.IsNewAlphalore)
            texAlphalore = await BestOptimizationeverSHAKALAlphalore.LoadTextureAlphalore(dataAlphalore1.CardImageAlphalore);
        _likeToggleAlphalore.interactable = true;
        UslessClassAlphalore.UselessMethodAlphalore();
        tokenAlphalore1.ThrowIfCancellationRequested();
        _loadingAlphalore.SetActive(false);
        _modImageAlphalore.texture = texAlphalore;
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();

    }

    public void Like()
    {

        isLikedAlphalore = !isLikedAlphalore;
        PlayerPrefs.SetInt(_itemDataAlphalore.CardImageAlphalore, (isLikedAlphalore) ? 1 : 0);

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void OnDisable()
    {

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        OnCancelLoadingAlphalore?.Invoke();

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void OnClickAlphalore()
    {

        PageManagerAlphalore.OnActivatePage.Invoke(2, _itemDataAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore();
    }
}
