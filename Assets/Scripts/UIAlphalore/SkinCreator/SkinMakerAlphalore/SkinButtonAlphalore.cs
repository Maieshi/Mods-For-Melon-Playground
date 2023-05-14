using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
public class SkinButtonAlphalore : MonoBehaviour
{
    public RawImage _skinImageAlphalore;
    [SerializeField] private Texture2D _deafaultTextureAlphalore;
    [SerializeField] private GameObject _loadingAlphalore;

    void Start()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        Button buttonAlphalore = GetComponent<Button>();
        // Debug.Log(buttonAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void OnClick()
    {
        SkinListCreatorAlphalore.OnSelectSkinAlphalore.Invoke((Texture2D)_skinImageAlphalore.texture);
        // Debug.Log("clickAlphalore".Replace("Alphalore", ""));

        UslessClassAlphalore.UselessMethodAlphalore();
    }
}
