using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FillWithIconPrefabs : MonoBehaviour
{
    [SerializeField] private FitterRefresher[] _refreshers;
    [SerializeField] private Object _prefab;
    [SerializeField] private Transform _resourceFolder;
    [SerializeField] private List<Resource> _resourcesToDisplayImmideately;
    [SerializeField] private Transform _displayerContainer;
    private readonly List<GameObject> _instantiatedIcons = new();

    private void Start()
    {
        var resources = _resourceFolder.GetComponentsInChildren<Resource>();

        foreach (var resource in resources)
        {
            CreateIcon(resource);
        }

        foreach (var resource in _resourcesToDisplayImmideately)
        {
            CreateDisplayer(resource);
        }

        gameObject.SetActive(false);
    }

    private void CreateDisplayer(Resource resource)
    {
        var icon = _instantiatedIcons.Find(icon => icon.GetComponent<ResourceHolder>().Resource == resource);
        if (icon != null)
        {
            var creator = icon.GetComponent<DisplayerCreator>();
            creator.IsMute = true;
            creator.CreateDisplayer();
            creator.IsMute = false;
        }
    }

    private void CreateIcon(Resource resource)
    {
        var icon = Instantiate(_prefab, transform) as GameObject;
        _instantiatedIcons.Add(icon);
        var resourceHolder = icon.GetComponent<ResourceHolder>();
        resourceHolder.Resource = resource;
        icon.GetComponent<Image>().sprite = resource.Icon;
        icon.GetComponent<TooltipOnHover>().SetText(resource.Name);
        var displayerCreator = icon.GetComponent<DisplayerCreator>();
        displayerCreator.Init(_displayerContainer, _refreshers);
    }
}
