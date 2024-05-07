using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class FitterRefresher : MonoBehaviour
{
    [SerializeField] private bool _refreshOnStart;
    RectTransform _rect;

    void Start()
    {
        GetRect();
        if (_refreshOnStart) Refresh();
    }

    public void Refresh()
    {
        GetRect();
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rect);
    }

    private void GetRect()
    {
        if (_rect == null) _rect = GetComponent<RectTransform>();
    }
}
