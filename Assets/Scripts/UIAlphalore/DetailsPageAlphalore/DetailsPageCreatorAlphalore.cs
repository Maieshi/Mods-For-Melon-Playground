using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DetailsPageCreatorAlphalore : SingletonPatternAlphalore<DetailsPageCreatorAlphalore>
{
    public CardDataAlphalore DetailsItemAlphalore;

    [SerializeField] private TextMeshProUGUI _modNameAlphalore;

    [SerializeField] private TextMeshProUGUI _modDescriptionAlphalore;

    [SerializeField] private RawImage _detailsImageAlphalore;

    [SerializeField] private DownloadButtonAlphalore _dowloadButton;
    private async void OnEnable()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        _dowloadButton._archiveAlphalore = DetailsItemAlphalore.CardArchiveAlphalore;
        _modNameAlphalore.text = DetailsItemAlphalore.CardNameAlphalore;
        _modDescriptionAlphalore.text = DetailsItemAlphalore.CardDestriptionAlphalore;
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        Texture2D detalisTextureAlphalore = await DownloadHandlerAlphalore.Instance.GetTextureAlphalore(DetailsItemAlphalore.CardImageAlphalore);
        if (!DetailsItemAlphalore.IsNewAlphalore)
            detalisTextureAlphalore = await BestOptimizationeverSHAKALAlphalore.LoadTextureAlphalore(DetailsItemAlphalore.CardImageAlphalore);
        _detailsImageAlphalore.texture = detalisTextureAlphalore;
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    public async void DownloadArchiveAlphalore()
    {
        Debug.Log(DetailsItemAlphalore.CardArchiveAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        await DownloadHandlerAlphalore.Instance.GetFileBytesAlphalore(DetailsItemAlphalore.CardArchiveAlphalore, false);
    }


}
