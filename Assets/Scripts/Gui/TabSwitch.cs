using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSwitch : MonoBehaviour
{
    [SerializeField] private TabSelector _selector;
    [SerializeField] private int _tabIndex;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeTab);
    }

    public void ChangeTab()
    {
        if (_selector.CurrentTab != _tabIndex)
            _selector.ChangeTab(_tabIndex);
        else
            _selector.ChangeTab(_selector.DefaultTab);
    }
}
