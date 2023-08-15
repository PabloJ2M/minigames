using UnityEngine;

public abstract class Save : MonoBehaviour
{
    protected string _path = Application.dataPath;

    [ContextMenu("Save")] public abstract void Set();
    [ContextMenu("Load")] public abstract void Get();
}