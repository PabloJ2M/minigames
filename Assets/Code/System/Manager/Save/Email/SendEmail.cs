using System;
using UnityEngine;
using UnityEngine.Events;

public class SendEmail : Save
{
    [SerializeField] private Email _email;
    [SerializeField] private Postmark _postmark;
    [SerializeField] private UnityEvent _onComplete;

    public override void Get() {}
    public override void Set()
    {
        if (_email.IsNullOrEmpty) { print("<color=red>emails are not provided</color>"); return; }
        print("<color=yellow>sending email...</color>");

        //add image to body message
        _email.Body = "";

        //smtp configuration
        System.Net.Mail.SmtpClient clienteSmtp = _postmark.SMTP;
        clienteSmtp.Credentials = _postmark.Credentials;

        //send email async
        System.Threading.Tasks.Task.Run(sendEmail);

        void sendEmail()
        {
            try { clienteSmtp.Send(_email.Message); print("<color=green>success</color>"); }
            catch (Exception e) { print(e.InnerException.Message); }
            _onComplete.Invoke();
        }
    }
}