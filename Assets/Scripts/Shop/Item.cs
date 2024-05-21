using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ShopItem ShopItem;
    public InfoDisplayer InfoDisplayer;
    private Button _button;
    private SoundPlayer _soundPlayer;

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
            affRes.Change *= affRes.Multiplier;
        }

        InfoDisplayer.Show(ShopItem);
        if (_soundPlayer != null) _soundPlayer.PlaySound(0);
    }
}
