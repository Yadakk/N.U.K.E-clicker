using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ReturnToMenu : MonoBehaviour
{
    private Button _button;
    private SceneLoader _sceneLoader;
    public string Message = "Warning: there's no saving system so progress will be lost!";
    public ConfirmerController ConfirmerController;

    private void Start()
    {
        _sceneLoader = GetComponent<SceneLoader>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => ConfirmerController.Display(() => _sceneLoader.Load(), Message));
    }
}
