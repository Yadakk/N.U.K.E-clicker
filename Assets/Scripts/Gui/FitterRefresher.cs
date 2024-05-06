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
        _rect = GetComponent<RectTransform>();
        if (_refreshOnStart) Refresh();
    }

    public void Refresh()
    {
        IEnumerator Routine()
        {
            yield return null;
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rect);
        }
        StartCoroutine(Routine());
    }
}
