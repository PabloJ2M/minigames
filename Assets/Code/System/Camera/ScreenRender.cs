using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ScreenRender : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private string _path;

    [SerializeField] private UnityEvent _onComplete;

    private WaitForEndOfFrame _frame = new WaitForEndOfFrame();

    public void TakeScreenShoot() => StartCoroutine(Task());

    private IEnumerator Task()
    {
        RenderTexture render = new(Screen.width, Screen.height, 20);
        _camera.targetTexture = render;
        _camera.Render();

        Texture2D texture = new(render.width, render.height, TextureFormat.RGB24, false);
        RenderTexture.active = render;
        yield return _frame;

        texture.ReadPixels(new(0, 0, render.width, render.height), 0, 0);
        texture.Apply();

        string path = Application.streamingAssetsPath + _path;
        byte[] bytes = texture.EncodeToJPG();
        yield return _frame;

        File.WriteAllBytes(path, bytes);
        RenderTexture.active = _camera.targetTexture = null;
        Destroy(render);

        _onComplete.Invoke();
    }
}