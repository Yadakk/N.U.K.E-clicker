using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utilities.RandomRollUtility;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Resource _increaseResource;
    [SerializeField] private Resource _increaseBy;
    [SerializeField] private Resource _criticalChance;
    [SerializeField] private Resource _criticalBreads;
    [SerializeField] private Resource _breads;
    [SerializeField] private PrefabThrower _capThrower;
    [SerializeField] private PrefabThrower _breadThrower;
    private SoundPlayer _capSoundPlayer;
    private SoundPlayer _breadSoundPlayer;

    private void Start()
    {
        _capSoundPlayer = _capThrower.GetComponent<SoundPlayer>();
        _breadSoundPlayer = _breadThrower.GetComponent<SoundPlayer>();
    }

    public void OnClick()
    {
        if (Roll(_criticalChance.Amount))
        {
            _increaseResource.Amount += _increaseBy.Amount * 3;
            _breads.Amount += _criticalBreads.Amount;
            _breadThrower.Throw();
            _breadSoundPlayer.PlaySound();
        }
        else
        {
            _increaseResource.Amount += _increaseBy.Amount;
        }
        _capThrower.Throw();
        _capSoundPlayer.PlaySound();
    }
}
