using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorButtonAlphalore : MonoBehaviour
{
    private Button _colorButton;

    [SerializeField] private Image _selectedColorImage;

    [SerializeField] private Color _changeColorAlphalore;

    [SerializeField] private bool _isChagesBackgound;

    private void Start()
    {
        _colorButton = GetComponent<Button>();
        _colorButton.GetComponent<Image>().color = _changeColorAlphalore;

        _colorButton.onClick.AddListener(() =>
        {
            _selectedColorImage.color = _changeColorAlphalore;
            if (!_isChagesBackgound)
                SkinEditorSettingsAlphalore.OnChangeColorAlphalore.Invoke(_changeColorAlphalore);
            else
                SkinEditorSettingsAlphalore.OnChangeBackgroundColorAlphalore.Invoke(_changeColorAlphalore);
        });
    }

}
