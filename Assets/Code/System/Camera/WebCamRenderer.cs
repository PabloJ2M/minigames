using UnityEngine;
using UnityEngine.Events;

public class WebCamRenderer : MonoBehaviour
{
    [SerializeField] private UnityEvent<Texture2D> _onUpdateRender;

    private WebCamTexture _webcamTexture = null;
    private Texture2D _texture = null;

    private WaitForSeconds _frameRate = new(0.1f);
    private WaitUntil _enable = null;

    private void Awake()
    {
        _webcamTexture = new WebCamTexture();
        _enable = new WaitUntil(() => _webcamTexture.isPlaying);

        _texture = Texture2D.blackTexture;
        _onUpdateRender.Invoke(_texture);
        _webcamTexture.Play();
    }
    private System.Collections.IEnumerator Start()
    {
        yield return _enable;

        _texture = new Texture2D(_webcamTexture.width, _webcamTexture.height);
        _texture?.SetPixels(_webcamTexture.GetPixels()); _texture?.Apply();
        _onUpdateRender.Invoke(_texture);

        yield return _frameRate;
        StartCoroutine(Start());
    }

    public void StopRendering() => _webcamTexture?.Stop();
    private void OnDestroy() => StopRendering();
}