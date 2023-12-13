using System.IO;
using UnityEngine;

public enum Format { none, png, jpg, csv }

public abstract class Save : MonoBehaviour
{
    [SerializeField] private string _file = "data";
    [SerializeField] private Format _format = Format.none;
    
    protected string _path = Application.dataPath;
    protected string _ruth => Path.Combine(_path, $"{_file}.{_format}");

    [ContextMenu("Save")] public abstract void Set();
    [ContextMenu("Load")] public abstract void Get();

    protected void Awake()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer: _path = Application.dataPath; break;
            case RuntimePlatform.WindowsEditor: _path = Application.streamingAssetsPath; break;
            case RuntimePlatform.IPhonePlayer | RuntimePlatform.Android: _path = Application.persistentDataPath; break;
        }
    }
}