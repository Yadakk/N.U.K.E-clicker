using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteriousStrangerPopup : MonoBehaviour
{
    public float HiddenY;
    public float DisplayedY;
    private RectTransform _rect;
    private float _lerpT;

    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        MysteriousStrangerChanceHandler.OnMysteriousStrangerCalled.AddListener(OnMysteriousStrangerCalledHandler);
    }

    private void OnDestroy()
    {
        MysteriousStrangerChanceHandler.OnMysteriousStrangerCalled.RemoveListener(OnMysteriousStrangerCalledHandler);
    }

    private void OnMysteriousStrangerCalledHandler()
    {

    }

    private void DisplayPopup()
    {
        Vector2 anchoredPosition = _rect.anchoredPosition;
        anchoredPosition.y = Mathf.Lerp(HiddenY, DisplayedY, _lerpT);
    }
}
