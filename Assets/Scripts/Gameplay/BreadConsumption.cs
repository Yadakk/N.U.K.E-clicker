using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreadConsumption : MonoBehaviour
{
    public Resource Breads;
    public Resource People;
    public Resource Score;
    public float PeoplePerBread = 50f;
    public float CooldownSeconds = 60f;

    private void Start()
    {
        StartCoroutine(BreadConsumptionRoutine());
    }

    private IEnumerator BreadConsumptionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CooldownSeconds);
            Breads.DisableFlash = true;
            People.DisableFlash = true;
            Score.DisableFlash = true;
            Breads.Amount -= Mathf.Ceil(People.Amount / PeoplePerBread);
            Breads.DisableFlash = false;
            People.DisableFlash = false;
            Score.DisableFlash = false;
        }
    }
}
