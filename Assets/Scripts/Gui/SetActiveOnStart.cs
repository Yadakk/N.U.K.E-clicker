using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SetActiveOnStart : MonoBehaviour
{
    [SerializeField] private List<ActivableObject> _activableObjects;

    private void Start()
    {
        _activableObjects.ForEach(obj => obj.SetActive());
    }
}

[System.Serializable]
public class ActivableObject
{
    public GameObject GameObject;
    public bool Active;

    public void SetActive()
    {
        GameObject.SetActive(Active);
    }
}