using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarsResetter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _button;
    public string PrefName;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ResetStars);
    }

    private void ResetStars()
    {
        PlayerPrefs.SetFloat(PrefName, 0f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowTooltipStatic("<color=red>Are you sure?</color>");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }
}
