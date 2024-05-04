using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class InfoDisplayer : MonoBehaviour
{
    private TextMeshProUGUI _tmpu;

    private void Start()
    {
        _tmpu = GetComponentInChildren<TextMeshProUGUI>();
        Hide();
    }

    private string PlusNotation(int num)
    {
        return num > 0 ? "+" + num : num.ToString();
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
        stringBuilder.Append(PlusNotation(affRes.Change));
        stringBuilder.Append(" ");
        stringBuilder.Append(affRes.Resource.Name);
        stringBuilder.Append(" | Next: ");
        stringBuilder.Append(PlusNotation(affRes.Change * affRes.Multiplier));
        return stringBuilder.ToString();
    }

    public void Hide()
    {
        _tmpu.text = string.Empty;
    }
}