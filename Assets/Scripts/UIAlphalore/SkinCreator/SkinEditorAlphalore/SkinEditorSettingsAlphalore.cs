using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinEditorSettingsAlphalore : BaseControllerAlphalore
{
    // [SerializeField] private Slider _colorOPT;
    // [SerializeField] private Image _colSliderBgOPT;
    // [SerializeField] private Slider _whiteToColorOPT;
    // [SerializeField] private RawImage _saturationBgOPT;
    // [SerializeField] private Slider _brushSizeOPT;
    // [Space]
    // [SerializeField] private Button _colorButtonOPT;
    // [SerializeField] private Image _buttonColIndicOPT;
    // [SerializeField] private Button _brushButtonOPT;
    // [SerializeField] private Button _fillButtonOPT;
    // [SerializeField] private Button _eraserButtonOPT;
    // [Space]
    // [SerializeField] private SimpleColPickerOPT _colPickerOPT;
    // [Space]
    // // [SerializeField] private Button _undoButtonOPT;
    // [SerializeField] private Button _redoButtonOPT;
    // [SerializeField] private Button _previewButtonOPT;
    // [SerializeField] private PreviewPanelOPT _previewPanelOPT;

    [SerializeField] private List<Image> _backgroundImages;

    public static Action<string> OnChangeEditModeAlphalore;

    public static Action<int> OnChangeBrushSizeAlphalore;

    public static Action<Color> OnChangeColorAlphalore;

    public static Action<Color> OnChangeBackgroundColorAlphalore;

    public Color _selectedColorAlphalore;

    // private float _gammaValueOPT = 1;
    private DrawningControllerAlphalore mainDrawAlphalore = null;
    // private GameObject _curSelected;

    public override void Awake()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        base.Awake();

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
    private void Start()
    {
        mainDrawAlphalore = ContainerAlphalore.GetAlphalore<DrawningControllerAlphalore>();

        OnChangeEditModeAlphalore += ChangeEditModeOPT;

        OnChangeColorAlphalore += SetColorChangesAlphalore;

        OnChangeBrushSizeAlphalore += (x) => { mainDrawAlphalore.ChangeBrushSizeAlphalore(x); };

        OnChangeBackgroundColorAlphalore += (x) => { foreach (var item in _backgroundImages) item.color = x; };
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();


        mainDrawAlphalore._currentEditTypeAlphalore = EditTypeAlphalore.FillAlphalore;

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void SetColorChangesAlphalore(Color colorAlphalore)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        if (mainDrawAlphalore == null)
            mainDrawAlphalore = ContainerAlphalore.GetAlphalore<DrawningControllerAlphalore>();
        mainDrawAlphalore.ChangeColorAlphalore(colorAlphalore);


        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    private void ChangeEditModeOPT(string stringToChageAlphalore)
    {
        stringToChageAlphalore += "Alphaloresrthfth".Replace("srthfth", "");
        EditTypeAlphalore toChangeOPT = (EditTypeAlphalore)Enum.Parse(typeof(EditTypeAlphalore), stringToChageAlphalore);
        // if (mainDrawOPT._currentEditTypeOPT == toChangeOPT)
        // {
        //     mainDrawOPT._currentEditTypeOPT = EditTypeOPT.AbleRotAlphalore;
        //     toChangeOPT = EditTypeOPT.AbleRotAlphalore;
        // }


        switch (toChangeOPT)
        {
            case EditTypeAlphalore.AbleRotAlphalore:
                // _brushButtonOPT.transform.GetChild(0).gameObject.SetActive(false);
                // _fillButtonOPT.transform.GetChild(0).gameObject.SetActive(false);
                // _colorButtonOPT.transform.GetChild(0).gameObject.SetActive(false);
                // _eraserButtonOPT.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case EditTypeAlphalore.ColorAlphalore:
                mainDrawAlphalore._currentEditTypeAlphalore = EditTypeAlphalore.ColorAlphalore;
                break;
            case EditTypeAlphalore.BrushAlphalore:
                mainDrawAlphalore._currentEditTypeAlphalore = EditTypeAlphalore.BrushAlphalore;
                break;
            case EditTypeAlphalore.FillAlphalore:
                mainDrawAlphalore._currentEditTypeAlphalore = EditTypeAlphalore.FillAlphalore;
                break;
            case EditTypeAlphalore.EraserAlphalore:
                mainDrawAlphalore._currentEditTypeAlphalore = EditTypeAlphalore.EraserAlphalore;
                break;
            case EditTypeAlphalore.BackAlphalore:
                mainDrawAlphalore._currentEditTypeAlphalore = EditTypeAlphalore.BackAlphalore;
                break;
        }

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
    // private void UndoStepOPT()
    // {
    //     var stepsOPT = mainDrawOPT._editedStepsOPT;
    //     var someOPT = stepsOPT[mainDrawOPT.CurrStepOPT];
    //     someOPT.RendOPT.material.mainTexture = Instantiate(someOPT.StTextureOPT);
    //     mainDrawOPT.CurrStepOPT -= 1;
    //     UpdateActiveStepsOPT();

    //     // trash =====================================================
    //     bool trashNeverTrueOPT = false; if (trashNeverTrueOPT) { bool[] trashfortrashOPT = new bool[12]; trashfortrashOPT[5] = !trashfortrashOPT[0]; for (int i = 0; i < trashfortrashOPT.Length; i++) { trashfortrashOPT[i] = !trashfortrashOPT[i]; trashfortrashOPT[i] = !trashfortrashOPT[i]; int asf1 = 12; float yepNope = float.Parse(asf1.ToString()); } }
    //     // trash =====================================================
    // }
    // private void RedoStepOPT()
    // {
    //     mainDrawOPT.CurrStepOPT += 1;
    //     var stepsOPT = mainDrawOPT._editedStepsOPT;
    //     var someOPT = stepsOPT[mainDrawOPT.CurrStepOPT];
    //     someOPT.RendOPT.material.mainTexture = Instantiate(someOPT.EndTextureOPT);
    //     UpdateActiveStepsOPT();

    //     // trash =====================================================
    //     bool trashNeverTrueOPT = false; if (trashNeverTrueOPT) { bool[] trashfortrashOPT = new bool[12]; trashfortrashOPT[5] = !trashfortrashOPT[0]; for (int i = 0; i < trashfortrashOPT.Length; i++) { trashfortrashOPT[i] = !trashfortrashOPT[i]; trashfortrashOPT[i] = !trashfortrashOPT[i]; int asf1 = 12; float yepNope = float.Parse(asf1.ToString()); } }
    //     // trash =====================================================
    // }
    // public void UpdateActiveStepsOPT()
    // {
    //     if (mainDrawOPT.CurrStepOPT > 0)
    //         _undoButtonOPT.interactable = true;
    //     else
    //         _undoButtonOPT.interactable = false;
    //     if (mainDrawOPT.CurrStepOPT >= 0 && mainDrawOPT._editedStepsOPT.Count - 1 > mainDrawOPT.CurrStepOPT)
    //         _redoButtonOPT.interactable = true;
    //     else
    //         _redoButtonOPT.interactable = false;

    //     // trash =====================================================
    //     bool trashNeverTrueOPT = false; if (trashNeverTrueOPT) { bool[] trashfortrashOPT = new bool[12]; trashfortrashOPT[5] = !trashfortrashOPT[0]; for (int i = 0; i < trashfortrashOPT.Length; i++) { trashfortrashOPT[i] = !trashfortrashOPT[i]; trashfortrashOPT[i] = !trashfortrashOPT[i]; int asf1 = 12; float yepNope = float.Parse(asf1.ToString()); } }
    //     // trash =====================================================
    // }

    protected override void AddToContainerAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        ContainerAlphalore.AddOPT<SkinEditorSettingsAlphalore>(this);

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }

    protected override void RemoveFromContainerAlphalore()
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        ContainerAlphalore.RemoveAlphalore<SkinEditorSettingsAlphalore>();

        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
    }
}
