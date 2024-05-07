using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ActiveToggler : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        _gameObject.SetActive(!_gameObject.activeSelf);
    }
}
