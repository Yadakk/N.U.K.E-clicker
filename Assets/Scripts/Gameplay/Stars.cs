using AssetBundleLib;
using JsonSaverLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour
{
    [SerializeField] private Resource _stars;
    [SerializeField] private string _path;

    private static Stars _instance;

    #region Initter
    private static readonly UnityEvent _initAll = new();
    private void Awake()
    {
        _initAll.AddListener(OnInitAll);
    }
    public static void InitAll()
    {
        _initAll.Invoke();
    }
    private void OnInitAll()
    {
        AssetUtility.GetFromBundle(Bootstrap.Bundle, ref _stars);

        _instance = this;
        Load();
    }
    #endregion

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        Saver.Save(_path, new SerializableInt(_stars.Amount));
    }

    private void Load()
    {
        if (Saver.Exists(_path))
        {
            _stars.Amount = Saver.Load<SerializableInt>(_path).Value;
        }
    }

    public static void SaveStatic()
    {
        _instance.Save();
    }

    public static void LoadStatic()
    {
        _instance.Load();
    }
}
