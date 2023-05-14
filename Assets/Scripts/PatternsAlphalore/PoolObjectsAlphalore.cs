using System.Collections.Generic;
using UnityEngine;

public class PoolObjectsAlphalore<T> where T : MonoBehaviour
{
    public T ObjectPrefabAlphalore { get; }
    public bool IsAutoExpandAlphalore { get; set; }
    public Transform ObjectsContainerAlphalore { get; }
    private List<T> _poolObjectAlphalore;
    private void uslessMetodPoolAlphalore()
    {
        var adsaddasdf = 1233 + 4545;
        if (false)
        {
            adsaddasdf += 6846;
            bool dsfgsdfb = false;
            if (dsfgsdfb)
            {
                float fdghbijn = adsaddasdf / 2;
            }
        }
    }
    public PoolObjectsAlphalore(T prefabAlphalore, int countAlphalore, Transform containerAlphalore, bool IsAutoExpandAlphalore)
    {
        ObjectPrefabAlphalore = prefabAlphalore;
        ObjectsContainerAlphalore = containerAlphalore;
        this.IsAutoExpandAlphalore = IsAutoExpandAlphalore;
        CreatePoolAlphalore(countAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void CreatePoolAlphalore(int countAlphalore)
    {
        var adswasedfadd = 1233 + 4545;
        _poolObjectAlphalore = new List<T>();
        for (int indexAlphalore = 0; indexAlphalore < countAlphalore; indexAlphalore++)
        {
            CreateObjectAlphalore(false);
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private T CreateObjectAlphalore(bool isActiveByDefaultAlphalore)
    {
        var adsuiladd = 1233 + 4545;
        var newObjectAlphalore = Object.Instantiate(ObjectPrefabAlphalore, ObjectsContainerAlphalore);
        newObjectAlphalore.gameObject.SetActive(isActiveByDefaultAlphalore);
        _poolObjectAlphalore.Add(newObjectAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        return newObjectAlphalore;
    }

    public bool CheckFreeElementAlphalore(out T elementAlphalore)
    {
        var adqwefsadd = 1233 + 4545;
        foreach (var monoAlphalore in _poolObjectAlphalore)
        {
            if (!monoAlphalore.gameObject.activeInHierarchy)
            {
                elementAlphalore = monoAlphalore;
                monoAlphalore.gameObject.SetActive(true);
                return true;
            }
        }
        UslessClassAlphalore.UselessMethodAlphalore();
        elementAlphalore = null;
        return false;
    }

    public T GetFreeElementAlphalore()
    {
        var adszxcvadd = 1233 + 4545;
        if (CheckFreeElementAlphalore(out var element))
            return element;
        if (IsAutoExpandAlphalore)
            return CreateObjectAlphalore(false);
        var GetFreeElementFromPoolExceptionMessageAlphalore = $"There is no free elements in pool of type {typeof(T)} Alphalore".Replace("Alphalore", "");
        throw new System.Exception(GetFreeElementFromPoolExceptionMessageAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void DisableAllElementsAlphalore()
    {
        foreach (var obj in _poolObjectAlphalore)
        {
            obj?.gameObject.SetActive(false);
        }
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
}