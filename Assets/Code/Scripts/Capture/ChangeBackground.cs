using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    [SerializeField] private GameObject[] _backgrounds;
    private int _current;

    private void Start() => Swipe(_current);
    private void Swipe(int index)
    {
        for (int i = 0; i < _backgrounds.Length; i++) _backgrounds[i].SetActive(i == index);
    }

    public void Previus()
    {
        _current--;
        _current = _current < 0 ? _backgrounds.Length - 1 : _current;
        Swipe(_current);
    }
    public void Next()
    {
        _current++;
        _current = _current >= _backgrounds.Length ? 0 : _current;
        Swipe(_current);
    }
}