using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlphaHit : MonoBehaviour
{
    [SerializeField] private float _threshold = 0.5f;

    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = _threshold;
    }
}
