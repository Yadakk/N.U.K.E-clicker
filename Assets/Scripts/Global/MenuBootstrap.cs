using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBootstrap : MonoBehaviour
{
    private void Start()
    {
        StartEnabler.Instance.EnableAll(true);
        TabSwitch.OnInitAll?.Invoke();
        StartEnabler.Instance.EnableAll(false);
    }
}
