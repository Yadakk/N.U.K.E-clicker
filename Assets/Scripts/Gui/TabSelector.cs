using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSelector : MonoBehaviour
{
    private int _currentTab;

    public void ChangeTab(int tab)
    {
        if (tab != _currentTab)
        {
            transform.GetChild(_currentTab).gameObject.SetActive(false);
            transform.GetChild(tab).gameObject.SetActive(true);
            _currentTab = tab;
        }
    }

    public enum Tabs
    {
        Main,
        Greed,
        Ego,
        Apathy,
    }
}