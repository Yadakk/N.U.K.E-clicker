using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemRewindTime : ShopItem
{
    public float MonthsToRewind = 12f;

    public override bool TryBuy()
    {
        if (!base.TryBuy()) return false;
        GameTimer.Instance.RemainingSeconds += MonthsToRewind * GameTimer.Instance.MonthDurationInSeconds;
        return true;
    }
}
