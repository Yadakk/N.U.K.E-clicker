using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusMinusButton : MonoBehaviour, IInitOnSceneLoad
{
    [field: SerializeField] public bool IsPlus { get; private set; }
    public Button Button { get; private set; }

    public void OnSceneLoad()
    {
        GetButton();
    }

    public void GetButton()
    {
        if (Button == null) Button = GetComponent<Button>();
    }
}