using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSwitch : MonoBehaviour
{
    [SerializeField] private TabSelector _selector;
    [SerializeField] private TabSelector.Tabs _tab;
    private Button _button;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void OnDisable()
    {
        OnInitAll -= InitAllHandler;
    }
    private void InitAllHandler()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeTab);
    }

    public void ChangeTab()
    {
        _selector.ChangeTab((int)_tab);
    }
}
