using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MakerToggleAlphalore : MonoBehaviour
{
    private Toggle _toggleAlphalore;

    [SerializeField] private Color _selectedColorAlphalore;

    [SerializeField] private Color _deselectedColorAlphalore;

    [SerializeField] private GameObject BackgroundAlphalore;

    [SerializeField] private Image _toggleIconAlphalore;

    [SerializeField] private TextMeshProUGUI _textAlphalore;
    void Start()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        _toggleAlphalore = GetComponent<Toggle>();
        _toggleAlphalore.onValueChanged.AddListener(ChangeSelection);

        ChangeSelection(true);

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void ChangeSelection(bool selectionValueAlphalore)
    {

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        selectionValueAlphalore = _toggleAlphalore.isOn;
        Color targetColorAlphalore = selectionValueAlphalore ? _selectedColorAlphalore : _deselectedColorAlphalore;
        BackgroundAlphalore.SetActive(selectionValueAlphalore);
        _toggleIconAlphalore.color = targetColorAlphalore;
        _textAlphalore.color = targetColorAlphalore;
        if (selectionValueAlphalore) SkinListCreatorAlphalore.OnSelectCategoryAlphalore.Invoke(_textAlphalore.text);

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
}
