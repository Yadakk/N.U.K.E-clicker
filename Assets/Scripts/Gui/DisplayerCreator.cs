using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

[RequireComponent(typeof(ResourceHolder), typeof(Button))]
public class DisplayerCreator : MonoBehaviour
{
    [SerializeField] private Object _displayerPrefab;
    public bool IsMute { get; set; }
    private SoundPlayer _soundPlayer;
    private Image _image;
    private Button _button;
    private GameObject _instantiatedDisplayer;
    private Transform _displayerContainer;
    private ResourceHolder _holder;
    private FitterRefresher[] _refreshers;

    public void Init(Transform targetDisplay, FitterRefresher[] refreshers)
    {
        _refreshers = refreshers;
        _displayerContainer = targetDisplay;
        _holder = GetComponent<ResourceHolder>();
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _soundPlayer = GetComponent<SoundPlayer>();
        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnClickHandler()
    {
        if (_instantiatedDisplayer == null)
            CreateDisplayer();
        else
            RemoveDisplayer();
    }

    public void RemoveDisplayer()
    {
        IEnumerator Routine()
        {
            yield return null;
            RefreshAll();
        }

        Destroy(_instantiatedDisplayer);
        _image.color = Color.white;
        if (!IsMute && _soundPlayer != null) _soundPlayer.PlaySound(1);
        StartCoroutine(Routine());
    }

    public void CreateDisplayer()
    {
        _instantiatedDisplayer = Instantiate(_displayerPrefab, _displayerContainer) as GameObject;
        _instantiatedDisplayer.GetComponent<ResourceDisplayer>().Init(_holder.Resource);
        _image.color = Color.green;
        if (!IsMute && _soundPlayer != null) _soundPlayer.PlaySound(0);
        RefreshAll();
    }

    private void RefreshAll()
    {
        foreach (var refresher in _refreshers)
            refresher.Refresh();
    }
}
