using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using System.Linq;
using UnityEngine.UI;
using static Utilities.IntBoolParseUtility;

[RequireComponent(typeof(Button))]
public class ChoiceTooltipDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventInformer _informer;
    [SerializeField] private bool _isPositive;
    private Button _button;
    private SoundPlayer _soundPlayer;
    public bool IsDisplayingTooltip { get; private set; }

    private void Start()
    {
        _button = GetComponent<Button>();
        _soundPlayer = GetComponent<SoundPlayer>();
        _button.onClick.AddListener(OnButtonClickHandler);
        _informer.OnDataHidden.AddListener(HideTooltip);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_informer.Data == null) return;
        StringBuilder builder = new();
        if (_isPositive) AppendChanges(_informer.Data.PositiveEffects, ref builder);
        else AppendChanges(_informer.Data.NegativeEffects, ref builder);
        Tooltip.ShowTooltipStatic(builder.ToString());
        IsDisplayingTooltip = true;
    }

    public void OnButtonClickHandler()
    {
        bool hasData = _informer.Data != null;
        if (hasData)
        {
            if (_isPositive)
            {
                ApplyChanges(_informer.Data.PositiveEffects);
                _informer.Caps.Amount += _informer.PositiveChoiceIncome.Amount;
            }
            else
            {
                ApplyChanges(_informer.Data.NegativeEffects);
                _informer.Breads.Amount += _informer.NegativeChoiceIncome.Amount;
            }
        }
        if (_soundPlayer != null) _soundPlayer.PlaySound(BoolToInt(!hasData));
    }

    private void ApplyChanges(EventBundle bundle)
    {
        bundle.GetAllResources().ToList().ForEach(evRes => evRes.ApplyChanges());
        _informer.ClearData(_informer.Controller);
        Tooltip.HideTooltipStatic();
        IsDisplayingTooltip = false;
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
        HideTooltip();
    }

    private void HideTooltip()
    {
        Tooltip.HideTooltipStatic();
        IsDisplayingTooltip = false;
    }
}