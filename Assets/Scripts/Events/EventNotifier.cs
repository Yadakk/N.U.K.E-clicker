using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventNotifier : MonoBehaviour
{
    [field: SerializeField] public Color NotificationColor { get; set; }
    private Color _defaultColor;
    private Image _image;
    private Button _button;
    private TextMeshProUGUI _tmpu;
    [SerializeField] private SoundPlayer _soundPlayer;
    private string _defaultText;
    private int _notificationCount = 0;
    [field: SerializeField] public string NotificationText { get; set; }

    private void Start()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _tmpu = GetComponentInChildren<TextMeshProUGUI>();
        _defaultColor = _image.color;
        _defaultText = _tmpu.text;
        _button.onClick.AddListener(ClearNotification);
    }

    public void Notify()
    {
        _notificationCount++;
        _image.color = NotificationColor;
        _tmpu.text = NotificationText + $"({_notificationCount})";
        if (_soundPlayer != null) _soundPlayer.PlaySound();
    }

    public void ClearNotification()
    {
        _image.color = _defaultColor;
        _tmpu.text = _defaultText;
        _notificationCount = 0;
    }
}
