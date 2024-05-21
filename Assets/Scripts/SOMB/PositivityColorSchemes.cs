using System.Text;
using Utilities;

public static class PositivityColorSchemes
{
    private static readonly PositivityColorScheme _negativeScheme = new("red", "white", "green");
    private static readonly PositivityColorScheme _neutralScheme = new("white", "white", "white");
    private static readonly PositivityColorScheme _positiveScheme = new("green", "white", "red");

    public static void FormatNumber(ref StringBuilder builder, PositivityColorScheme colorScheme, float num, bool forcePercentFormat)
    {
        switch (num)
        {
            case < 0: builder.Append($"<color={colorScheme.Negative}>"); break;
            case > 0: builder.Append($"<color={colorScheme.Positive}>"); break;
            default: builder.Append($"<color={colorScheme.Neutral}>"); break;
        }
        builder.Append(NumberFormatter.LeadingPlus(num));
        if (forcePercentFormat) builder.Append("%");
        builder.Append("</color>");
    }

    public static PositivityColorScheme PositivityToColorScheme(Resource res)
    {
        switch (res.ResourcePositivity)
        {
            case Resource.Positivity.Positive: return _positiveScheme;
            case Resource.Positivity.Negative: return _negativeScheme;
        }
        return _neutralScheme;
    }
}

public struct PositivityColorScheme
{
    public string Positive;
    public string Neutral;
    public string Negative;

    public PositivityColorScheme(string positive, string neutral, string negative)
    {
        Positive = positive;
        Neutral = neutral;
        Negative = negative;
    }
}