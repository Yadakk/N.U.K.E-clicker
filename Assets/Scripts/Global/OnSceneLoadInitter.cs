using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OnSceneLoadInitter : MonoBehaviour
{
    void Start()
    {
        Resources.FindObjectsOfTypeAll(typeof(MonoBehaviour)).OfType<IInitOnSceneLoad>().ToList().ForEach(mb => mb.OnSceneLoad());
    }
}

public interface IInitOnSceneLoad
{
    void OnSceneLoad();
}