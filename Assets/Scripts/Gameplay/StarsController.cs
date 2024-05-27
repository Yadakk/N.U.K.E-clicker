using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    public Resource Score;
    public Resource ClickPower;
    public float ScoreFor1Star = 25000f;
    public float ScoreFor2Stars = 50000f;
    public float ScoreFor3Stars = 100000f;
    private Resource _stars;

    private void Start()
    {
        _stars = GetComponent<Resource>();
        _stars.Amount = PlayerPrefs.GetFloat(name, 0f);
        ClickPower.Amount += _stars.Amount;
    }

    public void AddStars()
    {
        if (Score.Amount >= ScoreFor1Star)
        {
            _stars.Amount += 1f;
            IntersceneVariables.FinalStars = 1f;
            PlayerPrefs.SetFloat(name, _stars.Amount);
            return;
        }

        if (Score.Amount >= ScoreFor2Stars)
        {
            _stars.Amount += 2f;
            IntersceneVariables.FinalStars = 2f;
            PlayerPrefs.SetFloat(name, _stars.Amount);
            return;
        }

        if (Score.Amount >= ScoreFor3Stars)
        {
            _stars.Amount += 3f;
            IntersceneVariables.FinalStars = 3f;
            PlayerPrefs.SetFloat(name, _stars.Amount);
            return;
        }
    }
}
