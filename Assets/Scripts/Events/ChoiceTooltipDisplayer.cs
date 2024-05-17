using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using System.Linq;
using Utilities;

public class ChoiceTooltipDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EventInformer _informer;
    [SerializeField] private bool _isPositive;
    private static readonly ColorScheme _positiveScheme = new("green", "white", "red");
    private static readonly ColorScheme _neutralScheme = new("white", "white", "white");
    private static readonly ColorScheme _negativeScheme = new("red", "white", "green");

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_informer.Data == null) return;
        StringBuilder builder = new();
        if (_isPositive)
            _informer.Data.PositiveEffects.ResourceChanges.ToList().ForEach(evRes => builder.AppendLine(FormatResourceChange(evRes)));
        else
            _informer.Data.NegativeEffects.ResourceChanges.ToList().ForEach(evRes => builder.AppendLine(FormatResourceChange(evRes)));
        Tooltip.ShowTooltipStatic(builder.ToString());
    }

    private string FormatResourceChange(EventResourceChange evRes)
    {
        StringBuilder builder = new();
        ColorScheme colorScheme = PositivityToColorScheme(evRes.Resource);
        switch (evRes.Change)
        {
            case < 0: builder.Append($"<color={colorScheme.Negative}>"); break;
            case > 0: builder.Append($"<color={colorScheme.Positive}>"); break;
            default: builder.Append($"<color={colorScheme.Neutral}>"); break;
        }
        builder.Append(Formations.LeadingPlus(evRes.Change));
        if (evRes.Resource.PercentFormatted || evRes.IsPercentChange)
            builder.Append("%");
        builder.Append(" ");
        builder.Append(evRes.Resource.Name);
        builder.Append("</color>");
        return builder.ToString();
    }

    private ColorScheme PositivityToColorScheme(Resource res)
    {
        switch(res.ResourcePositivity)
        {
            case Resource.Positivity.Positive: return _positiveScheme;
            case Resource.Positivity.Negative: return _negativeScheme;
        }
        return _neutralScheme;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }

    private struct ColorScheme
    {
        public string Positive;
        public string Neutral;
        public string Negative;

        public ColorScheme(string positive, string neutral, string negative)
        {
            Positive = positive;
            Neutral = neutral;
            Negative = negative;
        }
    }
}