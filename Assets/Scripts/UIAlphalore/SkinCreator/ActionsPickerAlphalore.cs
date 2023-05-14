using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionsPickerAlphalore : MonoBehaviour
{
    private Toggle _actionsToggleAlphalore;

    [SerializeField] private GameObject _tragetAlphalore;

    void Start()
    {
        _actionsToggleAlphalore = GetComponent<Toggle>();
        _actionsToggleAlphalore.onValueChanged.AddListener(ChangeSelection);
        ChangeSelection(false);
    }

    private void ChangeSelection(bool value)
    {
        if (_actionsToggleAlphalore.isOn)
            _tragetAlphalore?.SetActive(true);
        else
            _tragetAlphalore?.SetActive(false);
    }
}
