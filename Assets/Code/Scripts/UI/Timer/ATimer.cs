using UnityEngine;
using UnityEngine.Events;

public abstract class ATimer : MonoBehaviour
{
    [SerializeField] protected float _time;
    [SerializeField] private UnityEvent _loseCondition;
    protected float _current;
    private bool _complete;

    private void Awake() => _current = _time;
    protected virtual void Update()
    {
        if (_complete) return;
        _current = _current > 0 ? _current -= Time.deltaTime : 0;
        if (_current <= 0) { _complete = true; _loseCondition.Invoke(); }
    }

    public void AddTime(float amount) => _current = Mathf.Clamp(_current += amount, 0, _time);
    public void RemoveTime(float amount) => _current = Mathf.Clamp(_current -= amount, 0, _time);
}