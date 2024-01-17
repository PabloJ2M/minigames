using UnityEngine;

[ExecuteAlways]
public class SizeFitter : MonoBehaviour
{
    private RectTransform _self;
    private float _height;

    private void Awake() => _self = GetComponent<RectTransform>();
    private void OnEnable() => UpdateHight();

    [ContextMenu("Update")] public void UpdateHight()
    {
        float height = 0f;
        foreach (RectTransform t in _self)
        {
            if (!t.gameObject.activeSelf) continue;
            if (t.sizeDelta.y > height) height += t.sizeDelta.y;
        }

        if (height == _height) return;
        _self.sizeDelta = new(_self.sizeDelta.x, height);
        _height = height;
    }
}