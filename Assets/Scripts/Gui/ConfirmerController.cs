using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ConfirmerController : MonoBehaviour
{
    private ConfirmerButton _confirmerButton;
    private TextMeshProUGUI _tmpu;

    public TextMeshProUGUI Tmpu
    {
        get
        {
            if (_tmpu == null) _tmpu = GetComponentInChildren<TextMeshProUGUI>();
            return _tmpu;
        }

        set => _tmpu = value;
    }

    public ConfirmerButton ConfirmerButton
    {
        get
        {
            if (_confirmerButton == null) _confirmerButton = GetComponentInChildren<ConfirmerButton>();
            return _confirmerButton;
        }

        set => _confirmerButton = value;
    }

    public void Display(UnityAction action, string message)
    {
        gameObject.SetActive(true);
        Tmpu.text = message;
        UnityAction disableObject = () => gameObject.SetActive(false);
        ConfirmerButton.SetAction(action + disableObject);
    }
}
