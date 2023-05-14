using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetRotatedAlphalore : MonoBehaviour, IPointerMoveHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform _playerAlphalore;
    float _angleAlphalore = 0;

    private bool _clickedAlphalore = false;

    public void OnPointerMove(PointerEventData eventData)
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        if (_clickedAlphalore)
        {
            UslessClassAlphalore.UselessMethodAlphalore();
            _angleAlphalore += Input.touches[0].deltaPosition.x * 3;
            _playerAlphalore.localRotation = Quaternion.Euler(0, -_angleAlphalore, 0);
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        _clickedAlphalore = false;
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        _clickedAlphalore = true;
        UslessClassAlphalore.UselessMethodAlphalore();
    }
}