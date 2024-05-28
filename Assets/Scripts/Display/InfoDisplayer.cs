using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using System;

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
            stringBuilder.AppendLine(affRes.ToString());
        }

        if (shopItem.BuysLeft > 0) AppendBuysLeft(shopItem, ref stringBuilder);

        _tmpu.text = stringBuilder.ToString();
    }

    private static void AppendBuysLeft(ShopItem shopItem, ref StringBuilder stringBuilder)
    {
        stringBuilder.Append("Items left: ");
        stringBuilder.AppendLine(shopItem.BuysLeft.ToString());
    }

    public void Hide()
    {
        _tmpu.text = string.Empty;
    }
}