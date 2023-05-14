using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawningControllerAlphalore : BaseControllerAlphalore
{
    [SerializeField] private Camera _camAlphalore;
    public EditTypeAlphalore _currentEditTypeAlphalore;

    private int _brushWidthAlphalore = 16;
    private int _brushHeightAlphalore = 16;

    private Color[] collorsAlphalore = new Color[256];
    private Color _currentColorAlphalore;
    public Action AfterAnimPreviewAlphalore;
    public int CurrStepAlphalore = 0;

    private Renderer _beginRendererAlphalore = null;
    private Texture2D _tempTextAlphalore = null;
    private SkinEditorSettingsAlphalore _skinEditorAlphalore;


    private Renderer _currentRendererAlphalore = null;
    public bool firstAlphalore = false;


    public override void Awake()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        Application.targetFrameRate = 60;
        base.Awake();
        ChangeColorAlphalore(Color.white);
        ChangeBrushSizeAlphalore(4);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void Start()
    {
        _skinEditorAlphalore = ContainerAlphalore.GetAlphalore<SkinEditorSettingsAlphalore>();


        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            UslessClassAlphalore.UselessMethodAlphalore();
            DrawAlphalore();
            if (_skinEditorAlphalore == null)
                _skinEditorAlphalore = ContainerAlphalore.GetAlphalore<SkinEditorSettingsAlphalore>();

            UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        }
    }



    private Renderer GetRendInstanceAlphalore(Renderer someAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        UslessClassAlphalore.UselessMethodAlphalore();

        Renderer yepAlphalore = new Renderer();
        yepAlphalore = someAlphalore;
        return yepAlphalore;
        UslessClassAlphalore.UselessMethodAlphalore();
    }


    private void DrawAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        bool IsAbleToDrawAlphalore = true;
        RaycastHit hitAlphalore;
        Touch touchAlphalore = Input.touches[0];

        UslessClassAlphalore.UselessMethodAlphalore();

        if (!Physics.Raycast(_camAlphalore.ScreenPointToRay(Input.mousePosition), out hitAlphalore))
            return;
        Renderer rendAlphalore = hitAlphalore.transform.GetComponent<Renderer>();
        MeshCollider meshColliderAlphalore = hitAlphalore.collider as MeshCollider;

        if (rendAlphalore == null || rendAlphalore.sharedMaterial == null || rendAlphalore.sharedMaterial.mainTexture == null || meshColliderAlphalore == null)
            IsAbleToDrawAlphalore = false;

        Texture2D texAlphalore = new Texture2D(2, 2, TextureFormat.RGB24, true);
        if (IsAbleToDrawAlphalore)
            texAlphalore = rendAlphalore.material.mainTexture as Texture2D;
        TouchPhase phaseAlphalore = touchAlphalore.phase;
        UslessClassAlphalore.UselessMethodAlphalore();
        switch (phaseAlphalore)
        {
            case TouchPhase.Began:
                _currentRendererAlphalore = rendAlphalore;
                if (_currentEditTypeAlphalore == EditTypeAlphalore.AbleRotAlphalore || _currentEditTypeAlphalore == EditTypeAlphalore.ColorAlphalore || !IsAbleToDrawAlphalore)
                    break;

                Texture2D CurTextureAlphalore = new Texture2D(2, 2, TextureFormat.RGB24, true);
                var tempTextureAlphalore = rendAlphalore.material.mainTexture as Texture2D;
                CurTextureAlphalore = Instantiate(tempTextureAlphalore);


                var bAlphalore = Instantiate(CurTextureAlphalore);
                _tempTextAlphalore = bAlphalore;
                if (_beginRendererAlphalore == null)
                    _beginRendererAlphalore = GetRendInstanceAlphalore(rendAlphalore);

                OriginsDataContainerAlphalore.SetAlphalore(new OriginsDataAlphalore() { orRendAlphalore = GetRendInstanceAlphalore(rendAlphalore), orTextAlphalore = Instantiate(CurTextureAlphalore) });


                rendAlphalore.material.SetTexture("_MainTexAlphlore".Replace("Alphlore", ""), CurTextureAlphalore);
                texAlphalore = CurTextureAlphalore;
                texAlphalore.filterMode = FilterMode.Point;
                UslessClassAlphalore.UselessMethodAlphalore();
                break;
            case TouchPhase.Ended:

                if (_currentEditTypeAlphalore == EditTypeAlphalore.AbleRotAlphalore || _currentEditTypeAlphalore == EditTypeAlphalore.ColorAlphalore || _tempTextAlphalore == null)
                    break;

                _beginRendererAlphalore = null;
                _currentRendererAlphalore = null;
                CurrStepAlphalore++;
                UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
                break;
        }

        if (rendAlphalore != _currentRendererAlphalore || !IsAbleToDrawAlphalore)
            return;

        switch (_currentEditTypeAlphalore)
        {
            case EditTypeAlphalore.AbleRotAlphalore:
                break;
            case EditTypeAlphalore.BrushAlphalore:
                Vector2 pixelUVAlphalore = hitAlphalore.textureCoord;
                pixelUVAlphalore.x *= texAlphalore.width;
                pixelUVAlphalore.y *= texAlphalore.height;
                texAlphalore.SetPixels((int)pixelUVAlphalore.x, (int)pixelUVAlphalore.y, _brushWidthAlphalore, _brushHeightAlphalore, collorsAlphalore);
                texAlphalore.Apply(true);
                UslessClassAlphalore.UselessMethodAlphalore();
                break;
            case EditTypeAlphalore.FillAlphalore:

                int baseAmmountOfPixelsAlphalore = texAlphalore.height * texAlphalore.width;
                Color[] colorToFillAlphalore = new Color[baseAmmountOfPixelsAlphalore];
                for (int i = 0; i < colorToFillAlphalore.Length; i++)
                {
                    colorToFillAlphalore[i] = _currentColorAlphalore;
                }
                for (int xPixAlphalore = 0; xPixAlphalore < texAlphalore.width; xPixAlphalore++)
                {
                    texAlphalore.SetPixels(xPixAlphalore, 0, 1, texAlphalore.height, colorToFillAlphalore);
                }
                texAlphalore.Apply(true);
                UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
                break;
            case EditTypeAlphalore.EraserAlphalore:

                Vector2 UVeraserAlphalore = hitAlphalore.textureCoord;
                UVeraserAlphalore.x *= texAlphalore.width;
                UVeraserAlphalore.y *= texAlphalore.height;
                Texture2D textureAlphalore = OriginsDataContainerAlphalore.GetAlphalore(rendAlphalore).orTextAlphalore;
                Color[] eraseColAlphalore = textureAlphalore.GetPixels((int)UVeraserAlphalore.x, (int)UVeraserAlphalore.y, _brushWidthAlphalore, _brushHeightAlphalore, 0);
                texAlphalore.SetPixels((int)UVeraserAlphalore.x, (int)UVeraserAlphalore.y, _brushWidthAlphalore, _brushHeightAlphalore, eraseColAlphalore);
                texAlphalore.Apply(true);
                UslessClassAlphalore.UselessMethodAlphalore();
                break;
        }
        UslessClassAlphalore.UselessMethodAlphalore();

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    public void ChangeColorAlphalore(Color brushColorAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        _currentColorAlphalore = brushColorAlphalore;
        for (int i = 0; i < collorsAlphalore.Length; i++)
        {
            collorsAlphalore[i] = brushColorAlphalore;
        }

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
    public void ChangeBrushSizeAlphalore(int someSizeAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        int newSizeAlphalore = someSizeAlphalore * 2;
        _brushWidthAlphalore = newSizeAlphalore;
        _brushHeightAlphalore = newSizeAlphalore;

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
    protected override void AddToContainerAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        ContainerAlphalore.AddOPT<DrawningControllerAlphalore>(this);
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    protected override void RemoveFromContainerAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        ContainerAlphalore.RemoveAlphalore<DrawningControllerAlphalore>();

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
}
