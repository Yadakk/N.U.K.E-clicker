using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        yield return new WaitWhile(() => GameTimer.Instance == null);
        while (true)
        {
            _image.fillAmount = GameTimer.Instance.Remaining / GameTimer.Instance.Seconds;
            yield return null;
        }
    }
}
