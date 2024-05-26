using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using static Resource;
using static Utilities.NumberFormatterUtility;

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
    private ScoreCalculator _scoreCalculator;
    private BreadConsumption _breadConsumption;

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
        _scoreCalculator = _resourceToDisplay.GetComponent<ScoreCalculator>();
        _breadConsumption = _resourceToDisplay.GetComponent<BreadConsumption>();

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
        if (_scoreCalculator != null)
        {
            builder.AppendLine("-----");
            builder.AppendLine("Formula for calculation:");
            FormatResourceFormula(ref builder, _scoreCalculator.Caps, _scoreCalculator.ScorePerCap);
            FormatResourceFormula(ref builder, _scoreCalculator.Breads, _scoreCalculator.ScorePerBread);
            FormatResourceFormula(ref builder, _scoreCalculator.People, _scoreCalculator.ScorePerPerson);
        }
        if (_breadConsumption != null)
        {
            builder.AppendLine("-----");
            builder.Append("1 - ");
            builder.Append(_breadConsumption.PeoplePerBread.ToString());
            builder.AppendLine(" people");
            builder.Append("consume 1 bread per ");
            builder.Append(_breadConsumption.CooldownSeconds);
            builder.AppendLine(" seconds");
            builder.Append((_breadConsumption.PeoplePerBread + 1f).ToString());
            builder.Append(" - ");
            builder.Append((_breadConsumption.PeoplePerBread * 2f).ToString());
            builder.AppendLine(" people");
            builder.AppendLine("consume 2 breads and so on...");
        }
        _tooltipOnHover.SetText(builder.ToString());
    }

    private void FormatResourceFormula(ref StringBuilder builder, Resource res, float scorePerUnit)
    {
        builder.Append(res.Name);
        builder.Append(" * ");
        builder.Append(scorePerUnit);
        builder.AppendLine(" + ");
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
        FlashColor(newVal, oldVal);
    }

    private void FlashColor(float newVal, float oldVal)
    {
        if (_resourceToDisplay.DisableFlash) return;
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

    private void UpdateCounter(float newVal)
    {
        StringBuilder builder = new();
        builder.Append(ToKMB(newVal));
        if (_resourceToDisplay.IsPercentFormatted) builder.Append("%");
        _text.text = builder.ToString();
    }
}
