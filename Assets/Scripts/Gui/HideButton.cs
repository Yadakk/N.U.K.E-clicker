using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButton : MonoBehaviour
{
    public GameObject ObjectToHide;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => ObjectToHide.SetActive(false));
    }
}
