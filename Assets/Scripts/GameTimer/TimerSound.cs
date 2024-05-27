using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundPlayer), typeof(TimerTooltip))]
public class TimerSound : MonoBehaviour
{
    private SoundPlayer _soundPlayer;
    private TimerTooltip _tooltip;

    private void Start()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
        _tooltip = GetComponent<TimerTooltip>();
        GameTimer.Instance.OnMonthsAmountChanged.AddListener(OnMonthsAmountChangedHandler);
    }

    private void OnMonthsAmountChangedHandler()
    {
        if (_tooltip.RemainingMonths % 12 == 0)
            _soundPlayer.PlaySound(1);
        else
            _soundPlayer.PlaySound(0);
    }
}
