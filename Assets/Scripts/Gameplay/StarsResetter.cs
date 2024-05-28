using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StarsResetter : MonoBehaviour
{
    private Button _button;
    public string PrefName;
    public string Message = "Are you sure?";
    public ConfirmerController ConfirmerController;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => ConfirmerController.Display(ResetStars, Message));
    }

    private void ResetStars()
    {
        PlayerPrefs.SetFloat(PrefName, 0f);
    }
}
