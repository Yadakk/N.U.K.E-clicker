using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class RandomUpgrader : MonoBehaviour
{
    private ShopItem _item;

    private void Start()
    {
        _item = GetComponent<ShopItem>();
    }
    
}
