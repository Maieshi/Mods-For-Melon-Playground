using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class OriginsDataContainerAlphalore
{
    private static List<OriginsDataAlphalore> _originsAlphalore = new List<OriginsDataAlphalore>();

    public static OriginsDataAlphalore GetAlphalore(Renderer rendAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        return _originsAlphalore.Find(x => x.orRendAlphalore == rendAlphalore);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public static void SetAlphalore(OriginsDataAlphalore originAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        OriginsDataAlphalore itemAlphalore = _originsAlphalore.Find(x => x.orRendAlphalore == originAlphalore.orRendAlphalore);
        if (itemAlphalore.Equals(default(OriginsDataAlphalore)))
            _originsAlphalore.Add(originAlphalore);
        else
            itemAlphalore.orTextAlphalore = originAlphalore.orTextAlphalore;
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
}
[Serializable]
public struct OriginsDataAlphalore
{
    public Renderer orRendAlphalore;
    public Texture2D orTextAlphalore;
    public int orIntAlphalore;
    public bool orBoolAlphalore;
    public void orMethodAlhalore()
    {
        orIntAlphalore = 684 - 54;
        orBoolAlphalore = false;
        if (orBoolAlphalore)
        {
            orIntAlphalore -= 684;
        }
    }
}

public enum EditTypeAlphalore
{
    AbleRotAlphalore,
    FillAlphalore,
    EraserAlphalore,
    ColorAlphalore,
    BrushAlphalore,
    BackAlphalore
}