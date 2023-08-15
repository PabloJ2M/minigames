using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UserData : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] _fields;
    [SerializeField] private UnityEvent _onSuccess;

    public static List<string> data = new List<string>();

    public void Continue()
    {
        data.Clear();

        for (int i = 0; i < _fields.Length; i++)
        {
            data.Add(_fields[i].text);
            if (string.IsNullOrWhiteSpace(data[i])) return;
        }

        _onSuccess.Invoke();
    }
}