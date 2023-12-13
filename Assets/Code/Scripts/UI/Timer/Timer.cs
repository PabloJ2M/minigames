using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] protected float _time;
    [SerializeField] private bool _complete;
    [SerializeField] private UnityEvent<string> _onValueChange;
    [SerializeField] private UnityEvent _onComplete;

    protected float _current;

    private void Awake() => _current = _time;
    protected virtual void Update()
    {
        if (_complete) return;
        if (_current > 0) RemoveTime(Time.deltaTime);
        if (_current <= 0) { _complete = true; _onComplete.Invoke(); }

        _onValueChange.Invoke(Format());
    }

    protected virtual string Format() => _current < 0.5f ? string.Empty : Mathf.RoundToInt(_current).ToString();
    public void AddTime(float amount) => _current = math.clamp(_current += amount, 0, _time);
    public void RemoveTime(float amount) => _current = math.clamp(_current -= amount, 0, _time);
    public void ResetValues() { _current = _time; _complete = false; }
    public void Complete() => _complete = true;
}