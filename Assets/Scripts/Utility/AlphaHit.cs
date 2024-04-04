using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlphaHit : MonoBehaviour
{
    [SerializeField] private float _threshold = 0.5f;

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
        GetComponent<Image>().alphaHitTestMinimumThreshold = _threshold;
    }
}
