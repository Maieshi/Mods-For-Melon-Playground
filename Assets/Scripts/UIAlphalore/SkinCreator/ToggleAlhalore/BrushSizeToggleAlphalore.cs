using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BrushSizeToggleAlphalore : MonoBehaviour
{
    private Toggle _toggleAlphalore;

    [SerializeField] private Color _selectedColorAlphalore;

    [SerializeField] private Color _deselectedColorAlphalore;

    [SerializeField] private TextMeshProUGUI _textAlphalore;

    void Start()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        _toggleAlphalore = GetComponent<Toggle>();
        _toggleAlphalore.onValueChanged.AddListener(ChangeSelection);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void ChangeSelection(bool selectionValueAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        selectionValueAlphalore = _toggleAlphalore.isOn;
        Color targetColorAlphalore = selectionValueAlphalore ? _selectedColorAlphalore : _deselectedColorAlphalore;
        _textAlphalore.color = targetColorAlphalore;
        if (selectionValueAlphalore) SkinEditorSettingsAlphalore.OnChangeBrushSizeAlphalore.Invoke(int.Parse(_textAlphalore.text.Replace("px", "")));
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

}
