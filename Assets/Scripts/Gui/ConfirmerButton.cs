using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ConfirmerButton : MonoBehaviour
{
    private UnityAction _action;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(InvokeAction);
    }

    private void InvokeAction()
    {
        _action.Invoke();
    }

    public void SetAction(UnityAction action)
    {
        _action = action;
    }
}
