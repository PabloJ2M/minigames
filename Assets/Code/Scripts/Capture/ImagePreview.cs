using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ImagePreview : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private RawImage _image;
    [SerializeField] private GameObject[] _hide;
    [SerializeField] private UnityEvent<bool> _onComplete;
    public static Texture2D texture;

    private void Start() => _onComplete.Invoke(false);
    public void TakePicture() => StartCoroutine(TakeScreenShoot());
    public System.Collections.IEnumerator TakeScreenShoot()
    {
        HideObjects(false);
        yield return new WaitForEndOfFrame();
        RenderTexture tempRT = new RenderTexture(_camera.pixelWidth, _camera.pixelHeight, 24);
        _camera.targetTexture = tempRT;
        _camera.Render();

        RenderTexture.active = tempRT;
        texture = new Texture2D(_camera.pixelWidth, _camera.pixelHeight);
        texture.ReadPixels(new Rect(0, 0, _camera.pixelWidth, _camera.pixelHeight), 0, 0);
        texture.Apply();

        yield return new WaitForEndOfFrame();
        _camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(tempRT);
        HideObjects(true);

        _onComplete.Invoke(true);
        _image.texture = texture;
    }
    private void HideObjects(bool value)
    {
        for (int i = 0; i < _hide.Length; i++) _hide[i].SetActive(value);
    }
}
