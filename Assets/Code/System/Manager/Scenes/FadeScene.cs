using System;

public class FadeScene : FadeCanvasGroup
{
    public Action onFadeScene;

    private void Start()
    {
        bool action = onFadeScene != null;
        _alpha = action ? 0 : 1;
        if (action) FadeIn();
        else FadeOut();
    }
    protected override void OnComplete()
    {
        base.OnComplete();
        if (onFadeScene == null) Destroy(gameObject);
        onFadeScene?.Invoke();
    }
}