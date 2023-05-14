using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CategoriesListAlphalore : SingletonPatternAlphalore<CategoriesListAlphalore>
{
    [SerializeField] private Transform _categoriesParentAlphalore;

    [SerializeField] private CategoryButtonAlphalore _buttonPrefabAlphalore;

    public static Action<string> OnChooseCategoryAlphalore;

    [HideInInspector] public List<string> CategoriesAlphalore;

    [SerializeField] private ToggleGroup _groupAlphalore;

    public List<string> AdditiveCategoriesAlphalore;


    private void Awake()
    {
        OnChooseCategoryAlphalore += ChooseCategoryAlphalore;
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void OnEnable()
    {
        if (_categoriesParentAlphalore.childCount > 0 || CategoriesAlphalore.Count == 0) return;
        UslessClassAlphalore.UselessMethodAlphalore();
        for (int additiveCategoryAlphalore = 0; additiveCategoryAlphalore < AdditiveCategoriesAlphalore.Count; additiveCategoryAlphalore++)
        {
            CreateCategoryAlphalore(AdditiveCategoriesAlphalore[additiveCategoryAlphalore]);
        }

        for (int categoryAlphalore = 0; categoryAlphalore < CategoriesAlphalore.Count; categoryAlphalore++)
        {
            CreateCategoryAlphalore(CategoriesAlphalore[categoryAlphalore]);
        }
        _groupAlphalore.SetAllTogglesOff();
        var togglesAlphalore = _groupAlphalore.GetComponentsInChildren<Toggle>();
        togglesAlphalore[AdditiveCategoriesAlphalore.Count].isOn = true;
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void CreateCategoryAlphalore(string categoryAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        CategoryButtonAlphalore buttonAlphalore = Instantiate(_buttonPrefabAlphalore, _categoriesParentAlphalore);
        buttonAlphalore._text = categoryAlphalore;
        buttonAlphalore.gameObject.GetComponent<Toggle>().group = _groupAlphalore;
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void ChooseCategoryAlphalore(string chosenCategoryAlphalore)
    {
        PageManagerAlphalore.OnActivatePage.Invoke(1, chosenCategoryAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore();
    }
}


