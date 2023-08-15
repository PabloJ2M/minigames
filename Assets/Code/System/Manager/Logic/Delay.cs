using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Delay : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private UnityEvent _onComplete;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_time);
        _onComplete.Invoke();
    }
}
