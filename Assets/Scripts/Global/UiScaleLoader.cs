using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScaleLoader : MonoBehaviour
{
    public string PrefName;
    private CanvasScaler _canvasScaler;
    private Vector2 _defaultResolution;
    public Vector2 MinMaxResolutionMultiplier = new(0.5f, 2f);
    public float Default;

    private void SetScale(float val)
    {
        _canvasScaler.referenceResolution = _defaultResolution * Mathf.Lerp(MinMaxResolutionMultiplier.x, MinMaxResolutionMultiplier.y, val);
    }

    private void Start()
    {
        _canvasScaler = ActiveCanvas.Canvas.GetComponent<CanvasScaler>();
        _defaultResolution = _canvasScaler.referenceResolution;
        SetScale(PlayerPrefs.GetFloat(PrefName, Default));
    }
}
