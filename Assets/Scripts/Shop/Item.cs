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
        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        bool boughtItem = ShopItem.TryBuy();
        if (boughtItem)
        {
            InfoDisplayer.Show(ShopItem);
            _soundPlayer.PlaySound(0);
            OnBoughtItemStatic.Invoke();
        }
        else
        {
            _soundPlayer.PlaySound(1);
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        InfoDisplayer.Show(ShopItem);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        InfoDisplayer.Hide();
    }
}
