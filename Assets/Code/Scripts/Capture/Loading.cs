using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject _self;
    [SerializeField] private Transform _icon;

    public void OnLoading(bool value) => _self.SetActive(value);

    private void Awake() => OnLoading(false);
    private void FixedUpdate()
    {
        if (!_self.activeSelf) return;
        _icon.Rotate(Vector3.back, 2);
    }
}
