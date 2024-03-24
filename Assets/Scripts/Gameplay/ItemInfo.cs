using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    private Coroutine _activateTooltip;

    public delegate void OnDisplayDelegate(bool display);
    public static OnDisplayDelegate OnDisplay;
    private void Awake()
    {
        OnDisplay += DisplayHandler;
        OnDisplay(true);
    }
    private void DisplayHandler(bool display)
    {
        if(display)
        {
            _activateTooltip = StartCoroutine(ActivateTooltip());
        }
        else
        {
            StopCoroutine(_activateTooltip);
            _activateTooltip = null;
        }
    }

    private IEnumerator ActivateTooltip()
    {
        transform.gameObject.SetActive(true);

        while(true)
        {
            transform.position = Input.mousePosition;
            yield return null;
        }
    }
}
