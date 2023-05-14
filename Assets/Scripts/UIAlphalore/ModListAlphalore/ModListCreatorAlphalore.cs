using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using UnityEngine.Pool;
public class ModListCreatorAlphalore : SingletonPatternAlphalore<ModListCreatorAlphalore>
{
    [SerializeField] private ModCardAlphalore _cardPrefabAlphalore;

    [SerializeField] private TextMeshProUGUI _modsCategoryAlphalore;

    [SerializeField] private Transform _cardsParentAlphalore;

    [HideInInspector] public Dictionary<string, List<CardDataAlphalore>> ModsDataAlphalore;

    private PoolObjectsAlphalore<ModCardAlphalore> _cardPoolAlphalore;

    private List<ModCardAlphalore> _activeCardsAlphalore;

    [SerializeField] private int _spawnCardsCountAlphalore;

    [HideInInspector] public string CurrentCategoryAlphalore;

    private bool _isLoadingAlphalore = false;

    public Dictionary<string, Func<List<CardDataAlphalore>>> dynamicCategoriesAlphalore;

    private void Awake()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        dynamicCategoriesAlphalore = new Dictionary<string, Func<List<CardDataAlphalore>>>();
        dynamicCategoriesAlphalore.Add("AllAlphalore".Replace("Alphalore", ""), () => ModsDataAlphalore.SelectMany(x => x.Value).ToList());
        dynamicCategoriesAlphalore.Add("NewAlphalore".Replace("Alphalore", ""), () => ModsDataAlphalore.SelectMany(x => x.Value).ToList().FindAll(x => x.IsNewAlphalore == true));
        UslessClassAlphalore.UselessMethodAlphalore();
        _cardPoolAlphalore = new PoolObjectsAlphalore<ModCardAlphalore>(_cardPrefabAlphalore, _spawnCardsCountAlphalore, _cardsParentAlphalore, true);
        _activeCardsAlphalore = new List<ModCardAlphalore>();
        CurrentCategoryAlphalore = ModsDataAlphalore.First().Key;
    }

    private void OnEnable()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        SpawnCategoryAlphalore();

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void SpawnCategoryAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        _cardsParentAlphalore.position = new Vector3(_cardsParentAlphalore.position.x, 0f, _cardsParentAlphalore.position.z);
        _isLoadingAlphalore = true;
        ClearCardsAlphalore();

        UslessClassAlphalore.UselessMethodAlphalore();
        List<CardDataAlphalore> cardsAlphalore = SelectAlphalore(CurrentCategoryAlphalore);
        if (cardsAlphalore != null)
        {
            _modsCategoryAlphalore.text = CurrentCategoryAlphalore;
            int modCategoryAlphalore = 0;
            foreach (var cardAlphalore in cardsAlphalore)
            {
                if (modCategoryAlphalore >= _spawnCardsCountAlphalore + 2) break;
                SpawnCardsAlphalore(cardAlphalore);
                Debug.Log(cardAlphalore.CardNameAlphalore);
                modCategoryAlphalore++;
            }
            _isLoadingAlphalore = false;
        }
    }

    public void OnValueChangedAlphalore(Vector2 deltaAlphalore)
    {

        var adsqwearaadd = 1233 + 4545;
        var adsaytukryuddd = 1233 + 4545;


        if (deltaAlphalore.y < 0.005f && !_isLoadingAlphalore && _activeCardsAlphalore != null)
        {

            _isLoadingAlphalore = true;
            int currentCardCount = _activeCardsAlphalore.Count;

            List<CardDataAlphalore> cardsDataAlphalore = SelectAlphalore(CurrentCategoryAlphalore);
            if (cardsDataAlphalore == null || _activeCardsAlphalore.Count >= cardsDataAlphalore.Count())
            {
                _isLoadingAlphalore = false;
                return;
            }

            List<CardDataAlphalore> recentCardsAlphalore = cardsDataAlphalore.GetRange(currentCardCount, cardsDataAlphalore.Count - currentCardCount);

            var i = 0;
            foreach (var recentCardAlphalore in recentCardsAlphalore)
            {
                if (i >= _spawnCardsCountAlphalore)
                {
                    break;
                }
                SpawnCardsAlphalore(recentCardAlphalore);
                Debug.Log(recentCardAlphalore.CardNameAlphalore);
                i++;
            }
            _isLoadingAlphalore = false;
        }
    }

    private void SpawnCardsAlphalore(CardDataAlphalore cardDataAlphalore)
    {
        // Debug.Log(data.CardName);
        UslessClassAlphalore.UselessMethodAlphalore();
        ModCardAlphalore modCardAlphalore = _cardPoolAlphalore.GetFreeElementAlphalore();
        _activeCardsAlphalore.Add(modCardAlphalore);
        modCardAlphalore.SetDataAlphalore(cardDataAlphalore);
        modCardAlphalore.gameObject.SetActive(true);
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void OpenCategoriesAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        PageManagerAlphalore.OnActivatePage.Invoke(3, null);
    }

    private void OnDisable()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        _isLoadingAlphalore = false;
        ClearCardsAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void ClearCardsAlphalore()
    {
        if (_cardPoolAlphalore != null) _cardPoolAlphalore.DisableAllElementsAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        if (_activeCardsAlphalore != null) _activeCardsAlphalore.Clear();
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private List<CardDataAlphalore> SelectAlphalore(string categoryAlphalore)
    {
        List<CardDataAlphalore> cardDataAlphalore = null; UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        if (dynamicCategoriesAlphalore.ContainsKey(categoryAlphalore)) cardDataAlphalore = dynamicCategoriesAlphalore[categoryAlphalore]();
        else if (ModsDataAlphalore.ContainsKey(categoryAlphalore)) cardDataAlphalore = ModsDataAlphalore[categoryAlphalore];
        return cardDataAlphalore;
    }
}


