using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using System.Text;
using System.Linq;
public class ParserAlphalore : MonoBehaviour
{
    [SerializeField] private string _imagesPrefixAlphalore;

    [SerializeField] private string _archivesPrefixAlphalore;

    [SerializeField] private string _contentKeyAlphalore;
    public Dictionary<string, List<CardDataAlphalore>> _modsDataAlphalore { get; private set; }



    // persistent data path- C:/Users/-__-/AppData/LocalLow/Ilya Donets/mods-for-melon-playground-game
    public async UniTask<int> ParseAlphalore()
    {
        byte[] rawFileAlphalore = await DownloadHandlerAlphalore.Instance.GetFileBytesAlphalore(_contentKeyAlphalore, true);

        string fileAlphalore = Encoding.Default.GetString(rawFileAlphalore);

        ContentJsonAlphalore contentJsonAlphalore = ContentJsonAlphalore.FromJsonAlphalore1(fileAlphalore);
        _modsDataAlphalore = contentJsonAlphalore.ModsCategoriesAlphalore;
        foreach (var categoryAlphalore in contentJsonAlphalore.ModsCategoriesAlphalore)
        {
            foreach (var itemAlphalore in categoryAlphalore.Value)
            {
                itemAlphalore.CardImageAlphalore = _imagesPrefixAlphalore + itemAlphalore.CardImageAlphalore;
                itemAlphalore.CardArchiveAlphalore = _archivesPrefixAlphalore + itemAlphalore.CardArchiveAlphalore;
            }
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        return 1;
    }
}


