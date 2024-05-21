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
    private SoundPlayer _soundPlayer;

    private void Start()
    {
        _button = GetComponent<Button>();
        _soundPlayer = GetComponent<SoundPlayer>();
        _button.onClick.AddListener(OnButtonClickHandler);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_informer.Data == null) return;
        StringBuilder builder = new();
        if (_isPositive) AppendChanges(_informer.Data.PositiveEffects, ref builder);
        else AppendChanges(_informer.Data.NegativeEffects, ref builder);
        Tooltip.ShowTooltipStatic(builder.ToString());
    }

    public void OnButtonClickHandler()
    {
        if (_informer.Data != null)
        {
            if (_isPositive) ApplyChanges(_informer.Data.PositiveEffects);
            else ApplyChanges(_informer.Data.NegativeEffects);
        }
    }

    private void ApplyChanges(EventBundle bundle)
    {
        bundle.GetAllResources().ToList().ForEach(evRes => evRes.ApplyChanges());
        _informer.ClearData();
        Tooltip.HideTooltipStatic();
        if (_soundPlayer != null) _soundPlayer.PlaySound();
    }

    private void AppendChanges(EventBundle bundle, ref StringBuilder builder)
    {
        var allRes = bundle.GetAllResources();
        if (allRes.Length == 0) builder.Append("Nothing happens...");
        foreach (var evRes in allRes)
        {
            builder.AppendLine(evRes.FormatResourceChange());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }
}