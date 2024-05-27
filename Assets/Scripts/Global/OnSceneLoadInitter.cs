using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class OnSceneLoadInitter : MonoBehaviour
{
    void Start()
    {
        Resources.FindObjectsOfTypeAll(typeof(MonoBehaviour)).Where(ob => ob.GameObject().scene.name == gameObject.scene.name).OfType<IInitOnSceneLoad>().ToList().ForEach(initer => initer.OnSceneLoad());
    }
}

public interface IInitOnSceneLoad
{
    void OnSceneLoad();
}