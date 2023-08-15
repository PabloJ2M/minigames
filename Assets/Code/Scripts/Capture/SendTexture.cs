using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class SendTexture : MonoBehaviour
{
    [SerializeField] private Loading _loading;
    [SerializeField] private UnityEvent<string> _errorMessage;
    [SerializeField] private UnityEvent _onComplete;

    [ContextMenu("Send")] public void SendPicture(string mail) => StartCoroutine(SendMail(mail));

    private void Awake() => _errorMessage.Invoke("");
    private IEnumerator SendMail(string email)
    {
        if (string.IsNullOrWhiteSpace(email.Trim())) yield break;

        _loading.OnLoading(true);

        string url = "https://unityfeature.000webhostapp.com/send_image_to_email.php";
        byte[] bytes = ImagePreview.texture.EncodeToPNG();
        string base64String = Convert.ToBase64String(bytes);

        _errorMessage.Invoke("");

        WWWForm form = new WWWForm();
        form.AddField("email", email.Trim());
        form.AddField("image", base64String);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
        _loading.OnLoading(false);

        if (www.result != UnityWebRequest.Result.Success)
        {
            print(www.downloadHandler.text);
            yield return new WaitForSeconds(1);
        }

        _onComplete.Invoke();
    }
}