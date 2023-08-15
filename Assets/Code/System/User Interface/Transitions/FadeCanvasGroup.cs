using UnityEngine;
using Effects;

[RequireComponent(typeof(CanvasGroup))]
public class FadeCanvasGroup : Fade
{
    [Header("Canvas Group")]
    [SerializeField] private bool _affectRaycast;
    [SerializeField] private bool _affectInteraction;

    [HideInInspector, SerializeField] private CanvasGroup _group;

    protected override float _alpha { get => _group.alpha; set => _group.alpha = value; }

    private void Reset() => _group = GetComponent<CanvasGroup>();
    private void OnEnable() => _onFade += OnFadeComplete;
    private void OnDisable() => _onFade -= OnFadeComplete;

    private void OnFadeComplete(bool value)
    {
        if (_affectInteraction) _group.interactable = value;
        if (_affectRaycast) _group.blocksRaycasts = value;
    }
}