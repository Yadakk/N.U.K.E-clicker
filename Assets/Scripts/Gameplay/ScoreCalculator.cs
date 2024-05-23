using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Resource))]
public class ScoreCalculator : MonoBehaviour
{
    public Resource Caps;
    public Resource Breads;
    public Resource People;
    private Resource _score;

    private void Start()
    {
        _score = GetComponent<Resource>();
        Caps.OnAmountChange.AddListener(OnAnyResourceChangedHandler);
        Breads.OnAmountChange.AddListener(OnAnyResourceChangedHandler);
        People.OnAmountChange.AddListener(OnAnyResourceChangedHandler);
    }

    private void OnAnyResourceChangedHandler(float oldVal, float newVal)
    {
        _score.Amount = Caps.Amount + Breads.Amount * 100 + People.Amount * 100;
        IntersceneVariables.FinalScore = _score.Amount;
    }
}
