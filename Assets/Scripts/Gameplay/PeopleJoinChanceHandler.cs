using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utilities.RandomRollUtility;

public class PeopleJoinChanceHandler : MonoBehaviour
{
    public float RollChanceEverySeconds;
    public Vector2 PeopleIncrement;

    [SerializeField] private Resource _peopleJoinChance;
    [SerializeField] private Resource _people;
    [SerializeField] private Resource _finalScore;

    public delegate void OnInitAllDelegate();
    private void Start()
    {
        StartCoroutine(AddResCoroutine());
    }

    private IEnumerator AddResCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(RollChanceEverySeconds);
            if (Roll(_peopleJoinChance.Amount)) AddPeople();
        }
    }

    private void AddPeople()
    {
        _people.DisableFlash = true;
        _finalScore.DisableFlash = true;
        _people.Amount += Random.Range((int)PeopleIncrement.x, (int)PeopleIncrement.y + 1);
        _people.DisableFlash = false;
        _finalScore.DisableFlash = false;
    }
}
