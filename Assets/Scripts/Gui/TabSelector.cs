using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSelector : MonoBehaviour
{
    public int DefaultTab;
    private int _currentTab;

    public int CurrentTab { get => _currentTab; private set => _currentTab = value; }

    public void ChangeTab(int tab)
    {
        if (tab != _currentTab)
        {
            transform.GetChild(_currentTab).gameObject.SetActive(false);
            transform.GetChild(tab).gameObject.SetActive(true);
            _currentTab = tab;
        }
    }
}