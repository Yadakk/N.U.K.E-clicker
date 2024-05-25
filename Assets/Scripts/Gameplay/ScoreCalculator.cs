using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Resource))]
public class ScoreCalculator : MonoBehaviour
{
    public Resource Caps;
    public float ScorePerCap = 1f;
    public Resource Breads;
    public float ScorePerBread = 50f;
    public Resource People;
    public float ScorePerPerson = 100f;
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
        _score.Amount = Caps.Amount * ScorePerCap + 
                        Breads.Amount * ScorePerBread + 
                        People.Amount * ScorePerPerson;
        IntersceneVariables.FinalScore = _score.Amount;
        IntersceneVariables.FinalCaps = Caps.Amount;
        IntersceneVariables.ScorePerCap = ScorePerCap;
        IntersceneVariables.FinalBreads = Breads.Amount;
        IntersceneVariables.ScorePerBread = ScorePerBread;
        IntersceneVariables.FinalPeople = People.Amount;
        IntersceneVariables.ScorePerPerson = ScorePerPerson;
    }
}