using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnabler : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToEnableAndDisable;

    public static StartEnabler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void EnableAll(bool active)
    {
        foreach(GameObject obj in _objectsToEnableAndDisable)
        {
            obj.SetActive(active);
        }
    }
}
