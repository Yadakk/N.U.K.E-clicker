using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using System.Linq;
using Utilities;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChoiceTooltipDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventInformer _informer;
    [SerializeField] private bool _isPositive;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClickHandler);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_informer.Data == null) return;
        StringBuilder builder = new();
        if (_isPositive)
        {
            if (_informer.Data.PositiveEffects.GetAllResources().Length == 0) builder.Append("Nothing happens...");
            _informer.Data.PositiveEffects.GetAllResources().ToList().ForEach(evRes => builder.AppendLine(evRes.FormatResourceChange()));
        }
        else
        {
            if (_informer.Data.NegativeEffects.GetAllResources().Length == 0) builder.Append("Nothing happens...");
            _informer.Data.NegativeEffects.GetAllResources().ToList().ForEach(evRes => builder.AppendLine(evRes.FormatResourceChange()));
        }

        Tooltip.ShowTooltipStatic(builder.ToString());
    }

    public void OnButtonClickHandler()
    {
        if (_isPositive)
            _informer.Data.PositiveEffects.GetAllResources().ToList().ForEach(evRes => evRes.ApplyChanges());
        else
            _informer.Data.NegativeEffects.GetAllResources().ToList().ForEach(evRes => evRes.ApplyChanges());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }
}