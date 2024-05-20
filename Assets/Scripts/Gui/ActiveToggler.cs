using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

[RequireComponent(typeof(Button))]
public class ActiveToggler : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private Button _button;
    private SoundPlayer _soundPlayer;

    void Start()
    {
        _button = GetComponent<Button>();
        _soundPlayer = GetComponent<SoundPlayer>();
        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        bool isActive = _gameObject.activeSelf;
        _gameObject.SetActive(!isActive);
        if (_soundPlayer != null) _soundPlayer.PlaySound(IntBoolParseUtility.BoolToInt(isActive));
    }
}
