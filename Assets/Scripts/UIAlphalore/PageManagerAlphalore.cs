using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using Plugins.Scripts.Dropbox;
using System.Linq;
public class PageManagerAlphalore : MonoBehaviour
{
    public static Action<int, object> OnActivatePage;

    [SerializeField] private List<GameObject> _pagesAlphalore;

    [SerializeField] private ParserAlphalore _parserAlphalore;

    [SerializeField] private ModListCreatorAlphalore _modListCreatorAlphalore;

    [SerializeField] private DetailsPageCreatorAlphalore _detailsPageCreatorAlphalore;

    [SerializeField] private CategoriesListAlphalore _categoriesListAlphalore;

    private async void Start()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        OnActivatePage += ActivatePageAlphalore;
        await DropboxHelper.Initialize();
        await _parserAlphalore.ParseAlphalore();
        _modListCreatorAlphalore.ModsDataAlphalore = _parserAlphalore._modsDataAlphalore;
        _categoriesListAlphalore.CategoriesAlphalore = _parserAlphalore._modsDataAlphalore.Keys.ToList();
        ActivatePageAlphalore(1);
        await Task.Delay(500);
        GameObject objAlphalore = _pagesAlphalore[0];
        _pagesAlphalore[0] = null;
        Destroy(objAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        //_guidesCreator.gameObject.SetActive(true);
    }

    public void ActivatePageAlphalore(int pageNumberAlphalore, object valueAlphalore = null)
    {
        //0-loading screen
        //1-Mods List
        //2-Mod Detalisation

        UslessClassAlphalore.UselessMethodAlphalore();
        switch (pageNumberAlphalore)
        {
            case 1:
                _modListCreatorAlphalore.CurrentCategoryAlphalore = (string)valueAlphalore;
                break;

            case 2:
                _detailsPageCreatorAlphalore.DetailsItemAlphalore = (CardDataAlphalore)valueAlphalore;
                break;
        }

        foreach (var pageAlphalore in _pagesAlphalore)
        {
            pageAlphalore?.SetActive(false);
        }

        _pagesAlphalore[pageNumberAlphalore].SetActive(true);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void ActivatePageAlphalore(int pageNumber)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        foreach (var pageAlphalore in _pagesAlphalore)
        {
            pageAlphalore?.SetActive(false);
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        _pagesAlphalore[pageNumber].SetActive(true);
    }
}
