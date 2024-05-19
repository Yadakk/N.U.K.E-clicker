using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using Utilities;

public class InfoDisplayer : MonoBehaviour
{
    private TextMeshProUGUI _tmpu;

    private void Start()
    {
        _tmpu = GetComponentInChildren<TextMeshProUGUI>();
        Hide();
    }

    public void Show(ShopItem shopItem)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine(shopItem.Name);
        stringBuilder.AppendLine(shopItem.Desc);
        for (int i = 0; i < shopItem.AffectedResources.Length; i++)
        {
            var affRes = shopItem.AffectedResources[i];
            stringBuilder.AppendLine(GetAffectedResourceInfo(affRes));
        }
        _tmpu.text = stringBuilder.ToString();
    }

    private string GetAffectedResourceInfo(AffectedResource affRes)
    {
        StringBuilder stringBuilder = new();
        PositivityColorScheme scheme = PositivityColorSchemes.PositivityToColorScheme(affRes.Resource);
        PositivityColorSchemes.FormatNumber(ref stringBuilder, scheme, affRes.Change, affRes.Resource.IsPercentFormatted);
        stringBuilder.Append(" ");
        stringBuilder.Append(affRes.Resource.Name);
        return stringBuilder.ToString();
    }

    public void Hide()
    {
        _tmpu.text = string.Empty;
    }
}