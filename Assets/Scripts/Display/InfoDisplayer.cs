using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoDisplayer : MonoBehaviour
{
    private TextMeshProUGUI[] _texts;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void OnDisable()
    {
        OnInitAll -= InitAllHandler;
    }
    private void InitAllHandler()
    {
        _texts = new TextMeshProUGUI[transform.childCount];

        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i] = transform.GetChild(i).
                        GetComponent<TextMeshProUGUI>();
        }

        Hide();
    }

    private string PlusNotation(int num)
    {
        return num > 0 ? "+" + num : num.ToString();
    }

    public void Show(ShopItem shopItem)
    {
        _texts[0].text = shopItem.Name;
        _texts[1].text = shopItem.Desc;

        for (int i = 0; i < shopItem.AffectedResources.Length; i++)
        {
            var affRes = shopItem.AffectedResources[i];

            _texts[i + 2].text = PlusNotation(affRes.Change) +
                                 " " +
                                 affRes.Resource.Name +
                                 " | Next: " + PlusNotation(affRes.Change *
                                 affRes.Multiplier);
        }
    }

    public void Hide()
    {
        foreach (var t in _texts)
            t.text = null;
    }
}
