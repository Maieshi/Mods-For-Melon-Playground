using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
public class LoadingScreenAlphalore : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuAlphalore;

    [SerializeField] private List<Transform> _lettersAlphalore;
    [SerializeField] private Scrollbar _loadingScrollbar;

    private List<Transform> _currentLettersAlphalore = new List<Transform>();

    private Transform _letterToAddAlphalore;

    [SerializeField] private Transform _finishAlphalore;

    private float _onePartOfTimeGRFRSB = 0.03f;

    private float _loadingTimeGRFRSB = 2f;

    public float speedAlphalore;
    async void Start()
    {
        var adsaesrgwergdd = 1233 + 4545;
        var adsasdcvsdddd = 1233 + 4545;
        StartCoroutine(AddLetterToMoveAlphalore());
        StartCoroutine(MoveLettersAlphalore());
        StartCoroutine(MoveLoadingLine());
        await Task.Delay(2500);
        _mainMenuAlphalore.SetActive(true);
        UslessClassAlphalore.UselessMethodAlphalore();

    }

    private IEnumerator AddLetterToMoveAlphalore()
    {
        int letterIndexAlphalore = 0;
        while (letterIndexAlphalore < 3)
        {
            _letterToAddAlphalore = _lettersAlphalore[letterIndexAlphalore];
            letterIndexAlphalore++;
            yield return new WaitForSeconds(1f);
        }
        UslessClassAlphalore.UselessMethodAlphalore();
    }
    private IEnumerator MoveLettersAlphalore()
    {
        while (gameObject.activeSelf)
        {
            if (_letterToAddAlphalore)
            {

                _currentLettersAlphalore.Add(_letterToAddAlphalore);
                _letterToAddAlphalore = null;
            }

            foreach (var letterAlphalore in _currentLettersAlphalore)
            {
                // Debug.Log($"{letterAlphalore.position.y} > {_finishAlphalore.position.y}");
                if (letterAlphalore.position.y > _finishAlphalore.position.y)
                {

                    letterAlphalore.transform.Translate(Vector3.down * speedAlphalore * Time.deltaTime);
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private IEnumerator MoveLoadingLine()
    {
        _loadingScrollbar.size = 1;
        bool wasparsed = false;
        for (int i = 0; i < 1 / _onePartOfTimeGRFRSB; i++)
        {
            _loadingScrollbar.size -= _onePartOfTimeGRFRSB;
            yield return new WaitForSeconds(_loadingTimeGRFRSB / (1 / _onePartOfTimeGRFRSB));
        }
        // Debug.Log("Begin Load Content");

    }
}