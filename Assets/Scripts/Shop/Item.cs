using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ShopItem ShopItem;
    public InfoDisplayer InfoDisplayer;
    private Button _button;
    private SoundPlayer _soundPlayer;
    public static readonly UnityEvent OnBoughtItemStatic = new();

    private void Start()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TryBuy);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        InfoDisplayer.Show(ShopItem);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        InfoDisplayer.Hide();
    }

    public void TryBuy()
    {
        foreach (var affRes in ShopItem.AffectedResources)
        {
            if (!(affRes.Resource.Amount + affRes.Change >= affRes.Resource.MinLimit.Limit))
            {
                if (_soundPlayer != null) _soundPlayer.PlaySound(1);
                return;
            }
        }

        foreach (var affRes in ShopItem.AffectedResources)
        {
            affRes.Resource.Amount += affRes.Change;
            affRes.Change = affRes.RoundChangeToInt ? Mathf.RoundToInt(NewChange(affRes)) : NewChange(affRes);
        }

        InfoDisplayer.Show(ShopItem);
        if (_soundPlayer != null) _soundPlayer.PlaySound(0);
        OnBoughtItemStatic.Invoke();
    }

    private static float NewChange(AffectedResource affectedResource)
    {
        return affectedResource.Change * affectedResource.Multiplier;
    }
}
