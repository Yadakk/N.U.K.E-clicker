using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using static Resource;

public class ResourceDisplayer : MonoBehaviour
{
    private Resource _resourceToDisplay;
    private PositivityColorScheme _scheme;
    private Transform _icon;
    private Transform _value;
    private TmpuColorFlash _colorFlash;
    private Image _image;
    private TextMeshProUGUI _text;
    private TooltipOnHover _tooltipOnHover;

    public void Init(Resource resourceToDisplay)
    {
        _resourceToDisplay = resourceToDisplay;
        _scheme = PositivityColorSchemes.PositivityToColorScheme(_resourceToDisplay);

        _icon = transform.GetChild(0);
        _value = transform.GetChild(1);

        _colorFlash = _value.GetComponent<TmpuColorFlash>();
        _image = _icon.GetComponent<Image>();
        _text = _value.GetComponent<TextMeshProUGUI>();
        _tooltipOnHover = _icon.GetComponent<TooltipOnHover>();
        _image.sprite = _resourceToDisplay.Icon;
        _resourceToDisplay.OnAmountChange.AddListener(AmountChangeHandler);
        DisplayTooltip();
        UpdateCounter(_resourceToDisplay.Amount);
    }

    private void DisplayTooltip()
    {
        StringBuilder builder = new();
        builder.AppendLine(_resourceToDisplay.Name);
        FormatLimit(ref builder, _resourceToDisplay.MinLimit, false);
        FormatLimit(ref builder, _resourceToDisplay.MaxLimit, true);
        _tooltipOnHover.SetText(builder.ToString());
    }

    private void FormatLimit(ref StringBuilder builder, ResourceLimit limit, bool isUpper)
    {
        if (limit.HasLimit)
        {
            builder.AppendLine("-----");
            builder.Append(isUpper ? "Maximum amount: " : "Minimum amount: ");
            builder.AppendLine(limit.Limit.ToString());
            if (limit.LimitControlledByResourceAmount != null)
            {
                builder.Append("This limit is controlled by: ");
                builder.AppendLine(limit.LimitControlledByResourceAmount.Name);
            }
            if (limit.ExchangedResource != null)
            {
                builder.Append("When limit is surpassed, gets exchanged to: ");
                builder.AppendLine(limit.ExchangedResource.Name);
            }
            if (limit.TriggersGameOverOnLimit)
            {
                builder.AppendLine("<color=\"red\">Game ends when this limit is surpassed</color>");
            }
        }
    }

    private void AmountChangeHandler(float newVal, float oldVal)
    {
        UpdateCounter(newVal);
        if (newVal > oldVal)
        {
            switch (_scheme.Positive)
            {
                case "green": _colorFlash.FlashColor(Color.green); break;
                case "white": _colorFlash.FlashColor(Color.white); break;
                case "red": _colorFlash.FlashColor(Color.red); break;
            }
        }
        else if (newVal < oldVal)
        {
            switch (_scheme.Negative)
            {
                case "green": _colorFlash.FlashColor(Color.green); break;
                case "white": _colorFlash.FlashColor(Color.white); break;
                case "red": _colorFlash.FlashColor(Color.red); break;
            }
        }
    }

    private void UpdateCounter<T>(T newVal)
    {
        StringBuilder builder = new();
        if (_resourceToDisplay.IsPercentFormatted) builder.Append("%");
        _text.text = newVal.ToString();
    }
}
