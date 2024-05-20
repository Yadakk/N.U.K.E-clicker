using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

[RequireComponent(typeof(Button))]
public class SoundPlayerButton : SoundPlayer
{
    private Button _button;

    protected override void Start()
    {
        base.Start();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlaySound);
    }
}
