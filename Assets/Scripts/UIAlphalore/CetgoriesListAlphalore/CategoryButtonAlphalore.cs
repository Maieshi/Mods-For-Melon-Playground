using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CategoryButtonAlphalore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _categoryTextAlphalore;

    private Toggle _toggleAlphalore;

    private void Awake()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        _toggleAlphalore = GetComponent<Toggle>();
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    public string _text { get { return _categoryTextAlphalore.text; } set { _categoryTextAlphalore.text = value; } }

    public void SetCategoryAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        if (_toggleAlphalore.isOn)
        {
            CategoriesListAlphalore.OnChooseCategoryAlphalore.Invoke(_text);
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
}
