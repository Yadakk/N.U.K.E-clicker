using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ResultsTextDisplayer : MonoBehaviour
{
    private TextMeshProUGUI _tmpu;
    public string GoodEndingText;
    public string BadEndingText;

    private void Start()
    {
        _tmpu = GetComponent<TextMeshProUGUI>();
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine(IntersceneVariables.IsBadEnding ? BadEndingText : GoodEndingText);
        stringBuilder.AppendLine("-----");
        FormatScore(ref stringBuilder, "Caps", IntersceneVariables.FinalCaps, IntersceneVariables.ScorePerCap);
        FormatScore(ref stringBuilder, "Breads", IntersceneVariables.FinalBreads, IntersceneVariables.ScorePerBread);
        FormatScore(ref stringBuilder, "People", IntersceneVariables.FinalPeople, IntersceneVariables.ScorePerPerson);
        stringBuilder.Append("Final score: ");
        stringBuilder.AppendLine(IntersceneVariables.FinalScore.ToString());
        stringBuilder.Append("Gained stars: ");
        stringBuilder.Append(IntersceneVariables.FinalStars);
        _tmpu.text = stringBuilder.ToString();
    }

    private static void FormatScore(ref StringBuilder stringBuilder, string resName, float finalValue, float scorePerUnit)
    {
        stringBuilder.Append(resName);
        stringBuilder.Append(" in bunker: ");
        stringBuilder.Append(finalValue.ToString());
        stringBuilder.Append(" - ");
        stringBuilder.Append(finalValue * scorePerUnit);
        stringBuilder.AppendLine(" score");
    }
}
