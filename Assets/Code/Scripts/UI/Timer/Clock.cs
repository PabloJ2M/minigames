using UnityEngine;
using UnityEngine.Events;

public class Clock : ATimer
{
    [SerializeField] private UnityEvent<float> _onChangeValue;

    private void Start() => StringFormatter();
    private void StringFormatter() => _onChangeValue.Invoke(_current / _time);

    protected override void Update()
    {
        base.Update();
        StringFormatter();
    }
}
