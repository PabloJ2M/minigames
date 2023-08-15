using UnityEngine;
using UnityEngine.Events;

public class Timer : ATimer
{
    [SerializeField] private UnityEvent<string> _onChangeValue;

    private void Start() => StringFormatter();
    protected override void Update() { base.Update(); StringFormatter(); }

    private void StringFormatter()
    {
        int minutos = (int)_current / 60;
        int segundos = (int)_current % 60;

        string format = "{0:00}:{1:00}";
        _onChangeValue.Invoke(string.Format(format, minutos, segundos));
    }
}