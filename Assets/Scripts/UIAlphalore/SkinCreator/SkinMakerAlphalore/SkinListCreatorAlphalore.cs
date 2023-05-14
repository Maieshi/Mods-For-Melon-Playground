using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Pool;
using UnityEngine.UI;
using System.Threading.Tasks;
public class SkinListCreatorAlphalore : MonoBehaviour
{
    public static Action<string> OnSelectCategoryAlphalore;

    public static Action<Texture2D> OnSelectSkinAlphalore;

    [SerializeField] private Transform _cardsParentAlphalore;

    [SerializeField] private Transform _itemsParentAlphalore;

    [SerializeField] private SkinButtonAlphalore _cardPrefabAlphalore;

    [SerializeField] private int _spawCardsCountAlphalore;

    private string _currentCategoryAlphalore;

    private Coroutine _loadingCoroutineAlphalore;

    private ObjectPool<SkinButtonAlphalore> _skinsPoolAlphalore;

    // private List<IResourceLocation> _categorySkinLocationsAlphalore;
    private List<SkinButtonAlphalore> _currentSkinsAlphalore;

    [SerializeField] private List<Renderer> _renderersAlphalore;

    [SerializeField] private List<Texture2D> _deafultTexturesAlphalore;


    private Dictionary<Texture2D, string> _itemTexturesAlphalore;

    private AssetBundle _currentSkinsBundleAlphalore;

    private string _currentBundleCategoryAlphalore;

    private bool _isLoadingSkinsAlphalore = true;

    void Awake()
    {
        OnSelectSkinAlphalore += SelectSkinAlphalore;
        _skinsPoolAlphalore = new ObjectPool<SkinButtonAlphalore>
        (
            () =>
            {
                return Instantiate(_cardPrefabAlphalore, _cardsParentAlphalore);
            },
            (x) =>
            {
                x.gameObject.SetActive(true);
            },
            (x) =>
            {
                x.gameObject.SetActive(false);
            },
            null,
            true,
            5,
            500
        );
        UslessClassAlphalore.UselessMethodAlphalore();
        OnSelectCategoryAlphalore += LoadNewCategory;
        _currentSkinsAlphalore = new List<SkinButtonAlphalore>();
        // _categorySkinLocationsAlphalore = new List<IResourceLocation>();
        _itemTexturesAlphalore = new Dictionary<Texture2D, string>();

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    async void Start()
    {
        await Task.Delay(500);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        ClearSkinsAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
    private void LoadNewCategory(string categoryAlphalore)
    {
        _currentCategoryAlphalore = categoryAlphalore.ToLower();
        if (_loadingCoroutineAlphalore != null)
        {
            StopCoroutine(_loadingCoroutineAlphalore);
            _loadingCoroutineAlphalore = null;
        }
        else
        {
            _loadingCoroutineAlphalore = StartCoroutine(LoadNewCategoryCoroutineAlphalore(_currentCategoryAlphalore));
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void ClearSkinsAlphalore()
    {
        for (int textureIndexAlphalore = 0; textureIndexAlphalore < _deafultTexturesAlphalore.Count; textureIndexAlphalore++)
        {
            Renderer rendAlphalore = _renderersAlphalore[textureIndexAlphalore];
            Texture2D textureAlphalore = (_deafultTexturesAlphalore[textureIndexAlphalore] == null) ? Texture2D.whiteTexture : _deafultTexturesAlphalore[textureIndexAlphalore];
            rendAlphalore.material.SetTexture("_MainTexAlphalore".Replace("Alphalore", ""), textureAlphalore);
            // DrawningControllerAlphalore.OnSetOriginsDataAlphalore.Invoke();
            OriginsDataContainerAlphalore.SetAlphalore(new OriginsDataAlphalore() { orRendAlphalore = rendAlphalore, orTextAlphalore = textureAlphalore });
        }
        for (int childIndexAlphalore = 0; childIndexAlphalore < _itemsParentAlphalore.childCount; childIndexAlphalore++)
        {
            Destroy(_itemsParentAlphalore.GetChild(childIndexAlphalore).gameObject);
        }
    }
    public void UpdateCategoryAlphalore(Vector2 scrollPositionAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        // Debug.Log($"coroutuine {_loadingCoroutineAlphalore}, is loading{_isLoadingSkinsAlphalore}");
        if (_loadingCoroutineAlphalore == null && !_isLoadingSkinsAlphalore)
            _loadingCoroutineAlphalore = StartCoroutine(UpdateCategoryCoroutineAlphalore(scrollPositionAlphalore));
    }

    private IEnumerator LoadNewCategoryCoroutineAlphalore(string skinCategoryAlphalore)
    {
        _isLoadingSkinsAlphalore = true;
        // _categorySkinLocationsAlphalore = null;
        ClearSkins();
        yield return null;
        // _categorySkinLocationsAlphalore = DownloadHandlerAlphalore.Instance.GetCategoryLiksAlphalore(skinCategoryAlphalore).Result;
        // yield return new WaitWhile(() => { return _currentCategoryAlphalore == null; });
        _currentSkinsBundleAlphalore = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, skinCategoryAlphalore));
        _currentBundleCategoryAlphalore = skinCategoryAlphalore;
        for (int i = 1; i < 6; i++)
        {
            string skinNameAlphalore = skinCategoryAlphalore + $" ({i})";
            SpawnSkinAlphalore(skinNameAlphalore);
        }
        _loadingCoroutineAlphalore = null;
        _isLoadingSkinsAlphalore = false;
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private IEnumerator UpdateCategoryCoroutineAlphalore(Vector2 scrollPositionAlphalore1)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        //  Debug.Log($"scroll {scrollPositionAlphalore1.x} , category {_categorySkinLocationsAlphalore}, current{currentCardCount}");
        if (scrollPositionAlphalore1.x > 0.95)
        {
            _isLoadingSkinsAlphalore = true;
            int currentCardCount = _currentSkinsAlphalore.Count;
            if (currentCardCount < _currentSkinsBundleAlphalore.GetAllAssetNames().Length)
            {
                for (int i = currentCardCount; i < _currentSkinsBundleAlphalore.GetAllAssetNames().Length; i++)
                {
                    if (i > currentCardCount + 2) break;
                    string skinNameAlphalore = _currentCategoryAlphalore + $" ({i})";
                    SpawnSkinAlphalore(skinNameAlphalore);
                    yield return null;
                }
                UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
            }
        }
        _isLoadingSkinsAlphalore = false;
        _loadingCoroutineAlphalore = null;
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void ClearSkins()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        foreach (var skinAlphalore in _currentSkinsAlphalore)
        {
            _skinsPoolAlphalore.Release(skinAlphalore);
        }
        UslessClassAlphalore.UselessMethodAlphalore();
        _currentSkinsAlphalore.Clear();
        if (_currentSkinsBundleAlphalore)
            _currentSkinsBundleAlphalore.Unload(false);

        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void SelectSkinAlphalore(Texture2D textureAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        if (_currentCategoryAlphalore == "itemsAlphalore".Replace("Alphalore", ""))
        {
            if (_itemTexturesAlphalore.ContainsKey(textureAlphalore))
            {
                for (int childIndexAlphalore = 0; childIndexAlphalore < _itemsParentAlphalore.childCount; childIndexAlphalore++)
                {
                    Destroy(_itemsParentAlphalore.GetChild(childIndexAlphalore).gameObject);
                }
                // AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "items"));
                GameObject assetAlphalore = _currentSkinsBundleAlphalore.LoadAsset<GameObject>(_itemTexturesAlphalore[textureAlphalore]);
                GameObject instanceAlphalore = Instantiate(assetAlphalore, _itemsParentAlphalore);
                instanceAlphalore.transform.localPosition = Vector3.zero;
                instanceAlphalore.transform.localRotation = Quaternion.Euler(Vector3.zero);
            }
        }
        else
        {
            UslessClassAlphalore.UselessMethodAlphalore();
            SkinPosition positionAlphalore = (SkinPosition)Enum.Parse(typeof(SkinPosition), _currentCategoryAlphalore, true);
            _renderersAlphalore[(int)positionAlphalore].material.SetTexture("_MainTexAlphalore1".Replace("Alphalore1", ""), textureAlphalore);
            OriginsDataContainerAlphalore.SetAlphalore(new OriginsDataAlphalore() { orRendAlphalore = GetRendInstanceAlphalore(_renderersAlphalore[(int)positionAlphalore]), orTextAlphalore = Instantiate(textureAlphalore) });
            // _materialsAlphalore[(int)positionAlphalore].
            // DrawningControllerAlphalore.OnSetOriginsDataAlphalore.Invoke(new OriginsDataOPT() { orRendOPT = _renderersAlphalore[(int)positionAlphalore], orTextOPT = (Texture2D)_renderersAlphalore[(int)positionAlphalore].material.GetTexture("_MainTex") });
        }

        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private Renderer GetRendInstanceAlphalore(Renderer someAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore();

        Renderer yepAlphalore = new Renderer();
        yepAlphalore = someAlphalore;
        return yepAlphalore;
    }

    private void SpawnSkinAlphalore(string assetPathAlphalore)
    {
        Texture2D skinPreviewTextureAlphalore = Texture2D.whiteTexture;
        if (!_currentSkinsBundleAlphalore)
        {
            Debug.Log("Bundle NullAlphalore".Replace("Alphalore", ""));
            return;
        }
        if (assetPathAlphalore.Contains("itemsAlphalore".Replace("Alphalore", "")))
        {
            // Debug.Log("itemsselected");
            GameObject assetAlphalore = _currentSkinsBundleAlphalore.LoadAsset<GameObject>(assetPathAlphalore);
            Transform assetTransformAlphalore = Instantiate(assetAlphalore, new Vector3(500, 500, 500), Quaternion.identity).transform;
            skinPreviewTextureAlphalore = RuntimePreviewGenerator.GenerateModelPreview(assetTransformAlphalore);
            //skinPreviewTexture = AssetPreview.GetAssetPreview(asset);
            if (_itemTexturesAlphalore.ContainsKey(skinPreviewTextureAlphalore)) _itemTexturesAlphalore[skinPreviewTextureAlphalore] = assetPathAlphalore;
            else _itemTexturesAlphalore.Add(skinPreviewTextureAlphalore, assetPathAlphalore);
            Destroy(assetTransformAlphalore.gameObject);
            UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();

        }
        else
        {
            UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
            skinPreviewTextureAlphalore = _currentSkinsBundleAlphalore.LoadAsset<Texture2D>(assetPathAlphalore);
        }
        if (skinPreviewTextureAlphalore != Texture2D.whiteTexture)
        {
            SkinButtonAlphalore skinButtonAlphalore = _skinsPoolAlphalore.Get();
            skinButtonAlphalore._skinImageAlphalore.texture = skinPreviewTextureAlphalore;
            _currentSkinsAlphalore.Add(skinButtonAlphalore);
        }
        UslessClassAlphalore.UselessMethodAlphalore();
    }
}




public enum SkinPosition
{
    Faces,
    Torso,

    Pants
}