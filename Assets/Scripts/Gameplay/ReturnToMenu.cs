using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReturnToMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _button;
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = GetComponent<SceneLoader>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => _sceneLoader.Load());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowTooltipStatic("<color=red>Warning: there's no saving system so progress will be lost!</color>");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }
}
