using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnEscape : MonoBehaviour
{
    public ConfirmerController ConfirmerController;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        ConfirmerController.Display(Application.Quit, "Quit the game?");
    }
}
