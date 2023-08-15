using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    [SerializeField] private UnityEvent _onStart, _onComplete;

    private void Start()
    {
        TextAlpha(0);
        _onStart.Invoke();
    }
    private IEnumerator StartCount()
    {
        GameObject text = _text.gameObject;

        for (int i = 3; i > 0; i--)
        {
            TextAlpha(0);
            _text.SetText(i.ToString());
            _text.transform.localPosition = 50 * Vector2.up;

            LTSeq seq = LeanTween.sequence();
            seq.append(LeanTween.moveLocalY(text, 0, 0.1f).setOnUpdate(TextAlpha));
            seq.append(LeanTween.value(text, 1, 0, 0.9f).setOnUpdate(TextAlpha));
            
            yield return new WaitForSeconds(1);
        }

        _onComplete.Invoke();
    }

    private void TextAlpha(float a) => _text.alpha = a;
    public void StartEvent() => StartCoroutine(StartCount());
}