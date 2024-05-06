using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillWithIconPrefabs : MonoBehaviour
{
    [SerializeField] private FitterRefresher[] _refreshers;
    [SerializeField] private Object _prefab;
    [SerializeField] private Transform _resourceFolder;
    [SerializeField] private Transform _displayerContainer;

    private void Start()
    {
        var resources = _resourceFolder.GetComponentsInChildren<Resource>();

        foreach (var resource in resources)
        {
            var icon = Instantiate(_prefab, transform) as GameObject;
            icon.GetComponent<ResourceHolder>().Resource = resource;
            icon.GetComponent<Image>().sprite = resource.Icon;
            icon.GetComponent<TooltipOnHover>().SetText(resource.Name);
            icon.GetComponent<DisplayerCreator>().Init(_displayerContainer, _refreshers);
        }
    }
}
