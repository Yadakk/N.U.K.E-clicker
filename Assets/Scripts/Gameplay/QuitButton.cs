using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    public ConfirmerController ConfirmerController;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(DisplayConfirmer);
    }

    private void DisplayConfirmer()
    {
        ConfirmerController.Display(Application.Quit, "Quit the game?");
    }
}
