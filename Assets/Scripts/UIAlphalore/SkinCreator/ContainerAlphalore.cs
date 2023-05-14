using System;
using System.Collections.Generic;

public class ContainerAlphalore
{
    private static Dictionary<Type, BaseControllerAlphalore> _containerAlphalore = new Dictionary<Type, BaseControllerAlphalore>();

    public static void AddOPT<T>(T controllerAlphalore) where T : BaseControllerAlphalore
    {
        _containerAlphalore.Add(controllerAlphalore.GetType(), controllerAlphalore);

        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();

    }

    public static T GetAlphalore<T>() where T : BaseControllerAlphalore
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        if (_containerAlphalore.ContainsKey(typeof(T)))
        {
            BaseControllerAlphalore foundedAlphalore = _containerAlphalore[typeof(T)];
            return foundedAlphalore as T;
        }

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();

        return null;
    }

    public static void RemoveAlphalore<T>() where T : BaseControllerAlphalore
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        if (_containerAlphalore.ContainsKey(typeof(T)))
        {
            _containerAlphalore.Remove(typeof(T));
        }
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
    }


}
