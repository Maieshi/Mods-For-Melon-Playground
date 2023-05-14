using UnityEngine;

public class SingletonPatternAlphalore<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _currentThisInstanceAlphalore;
    private static string _uslesStringAlphalore;
    private void uslessMetodAlphalore()
    {
        var adsaddasdfkuih = 1233 + 4545;

        void asdfiuh()
        {
            var rtuifgbudfg = false;
            if (rtuifgbudfg)
            {
                adsaddasdfkuih += 651;
                float srthbjkergi = adsaddasdfkuih / 3.25f;
                if (srthbjkergi < 0)
                {
                    bool drhgkus = false;
                }
            }
        }
    }
    public static T Instance
    {
        get
        {
            if (_currentThisInstanceAlphalore == null)
            {
                _currentThisInstanceAlphalore = FindObjectOfType<T>();

                if (_currentThisInstanceAlphalore == null)
                {
                    Debug.Log("Cannot find jbject of type:Alphalore".Replace("Alphalore", "") + nameof(T));
                }
            }
            UslessClassAlphalore.UselessMethodAlphalore();
            return _currentThisInstanceAlphalore;
        }
    }
}