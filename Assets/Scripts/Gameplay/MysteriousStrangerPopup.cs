using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class MysteriousStrangerPopup : MonoBehaviour
{
    public RandomizableResource[] RandomizableResources;
    public float HiddenY;
    public float DisplayedY;
    public float PopupSpeed = 1f;
    public float DisplayTimeSeconds = 5f;
    private RectTransform _rect;
    private TextMeshProUGUI _tmpu;
    private SoundPlayer _soundPlayer;
    private float _timeRemainingSeconds;

    private void Start()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
        _tmpu = GetComponentInChildren<TextMeshProUGUI>();
        _rect = GetComponent<RectTransform>();
        SetPositionY(HiddenY);
        MysteriousStrangerChanceHandler.OnMysteriousStrangerCalled.AddListener(OnMysteriousStrangerCalledHandler);
    }

    private void Update()
    {
        _timeRemainingSeconds -= Time.deltaTime;
        if (_timeRemainingSeconds > DisplayTimeSeconds / 2)
            SetPositionY(Mathf.Lerp(_rect.anchoredPosition.y, DisplayedY, Time.deltaTime * PopupSpeed));
        else
            SetPositionY(Mathf.Lerp(_rect.anchoredPosition.y, HiddenY, Time.deltaTime * PopupSpeed));
    }

    private void OnDestroy()
    {
        MysteriousStrangerChanceHandler.OnMysteriousStrangerCalled.RemoveListener(OnMysteriousStrangerCalledHandler);
    }

    private void OnMysteriousStrangerCalledHandler()
    {
        DisplayPopup();
    }

    private void SetPositionY(float y)
    {
        Vector2 anchoredPosition = _rect.anchoredPosition;
        anchoredPosition.y = y;
        _rect.anchoredPosition = anchoredPosition;
    }

    private void DisplayPopup()
    {
        _soundPlayer.PlaySound();
        SetPositionY(HiddenY);
        _tmpu.text = RandomizableResources[Random.Range(0, RandomizableResources.Length - 1)].AddRandomToResource();
        _timeRemainingSeconds = DisplayTimeSeconds;
    }
}

[System.Serializable]
public class RandomizableResource
{
    public Resource Resource;
    public Vector2 RandomRangeChange;
    public bool RoundResultToInt;

    public string AddRandomToResource()
    {
        var change = Random.Range(RandomRangeChange.x, RandomRangeChange.y);
        Resource.Amount += change;
        if (RoundResultToInt) Resource.Amount = Mathf.Round(Resource.Amount);
        StringBuilder stringBuilder = new();
        stringBuilder.Append("You have received ");
        stringBuilder.Append(RoundResultToInt ? Mathf.Round(change) : change);
        stringBuilder.Append(" ");
        stringBuilder.Append(Resource.Name);
        stringBuilder.Append(" from the mysterious stranger");
        return stringBuilder.ToString();
    }
}
