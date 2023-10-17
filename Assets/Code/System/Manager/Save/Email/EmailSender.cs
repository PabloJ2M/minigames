using UnityEngine;
using UnityEngine.Events;
using SuperSimple;
using TMPro;

public class EmailSender : MonoBehaviour
{
    [Header("Sender")]
    [SerializeField] private string _fromEmail = "username@youraddress.com";
    [SerializeField] private string _password = "yourpassword";
    [SerializeField] private string _displatName = "EmailService Sender";

    [Header("Format")]
    [SerializeField] private string _subject = "SSEmail Example 2";
    [SerializeField, TextArea] private string _body = "this email has attachments";

    [SerializeField] private string _path;
    [SerializeField] private UnityEvent<string> _onResult;
    [SerializeField] private UnityEvent _onStart, _onComplete;

    private void Start()
    {
        print("settings configurated");
        EmailService.Instance.Initialize(new()
        {
            SmtpHost = "smtp.gmail.com",
            StmpPort = 587,
            EnableSSL = true,
            SenderEmail = _fromEmail,
            SenderPassword = _password,
            SenderName = _displatName
        });
    }
    public void Send(TMP_InputField field)
    {
        if (string.IsNullOrWhiteSpace(field.text)) return;

        _onStart.Invoke();
        _onResult.Invoke(string.Empty);

        string path = Application.streamingAssetsPath + _path;
        EmailService.Recipient[] recipient = { new() { Address = field.text } };
        EmailService.Instance.SendPlainText(recipient, _subject, _body, new string[] { path }, OnComplete);
    }
    private void OnComplete(bool task)
    {
        _onResult.Invoke(task ? "correo enviado" : "error");
        _onComplete.Invoke();
    }
}