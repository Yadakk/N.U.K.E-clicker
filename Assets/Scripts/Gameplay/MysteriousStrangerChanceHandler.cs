using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Utilities.RandomRollUtility;

public class MysteriousStrangerChanceHandler : MonoBehaviour
{
    public Resource MysteriousStrangerChance;
    public static readonly UnityEvent OnMysteriousStrangerCalled = new();

    private void Start()
    {
        Item.OnBoughtItemStatic.AddListener(OnPlayerActionHandler);
        EventController.OnAppliedChangesStatic.AddListener(OnPlayerActionHandler);
        ChoiceTooltipDisplayer.OnAppliedChangesStatic.AddListener(OnPlayerActionHandler);
    }

    private void OnDestroy()
    {
        Item.OnBoughtItemStatic.RemoveListener(OnPlayerActionHandler);
        EventController.OnAppliedChangesStatic.RemoveListener(OnPlayerActionHandler);
        ChoiceTooltipDisplayer.OnAppliedChangesStatic.RemoveListener(OnPlayerActionHandler);
    }

    private void OnPlayerActionHandler()
    {
        if (Roll(MysteriousStrangerChance.Amount))
        {
            OnMysteriousStrangerCalled.Invoke();
        }
    }
}
