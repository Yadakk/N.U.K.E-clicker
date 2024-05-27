using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiScaler : MonoBehaviour, IInitOnSceneLoad
{
    public Vector2 MinMaxResolutionMultiplier = new(0.5f, 2f);
    private ButtonsSetting _buttonsSetting;
    private CanvasScaler _canvasScaler;
    private Vector2 _defaultResolution;

    private void SetScale(float val)
    {
        _canvasScaler.referenceResolution = _defaultResolution * Mathf.Lerp(MinMaxResolutionMultiplier.x, MinMaxResolutionMultiplier.y, val);
    }

    public void OnSceneLoad()
    {
        _canvasScaler = ActiveCanvas.Canvas.GetComponent<CanvasScaler>();
        _buttonsSetting = GetComponent<ButtonsSetting>();
        _defaultResolution = _canvasScaler.referenceResolution;
        _buttonsSetting.OnValueChanged.AddListener(SetScale);
        SetScale(PlayerPrefs.GetFloat(_buttonsSetting.name, _buttonsSetting.Default));
    }
}
