using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private bool _enable;
    [SerializeField] private UnityEvent _onShow, _onHide;
    private TMP_InputField _textBox;

    private void Awake() => Instance = this;
    public void AddListerner(TMP_InputField field) { if (!_enable) return; _textBox = field; _onShow.Invoke(); }
    public void AddLetter(string letter) => _textBox?.SetTextWithoutNotify(_textBox.text + letter);
    public void SubmitWord() { if (!_enable) return; _onHide.Invoke(); }

    public void DeleteLetter()
    {
        if (_textBox.text.Length == 0) return;
        _textBox?.SetTextWithoutNotify(_textBox.text.Remove(_textBox.text.Length - 1, 1));
    }
}