using System;
using System.Net.Mail;
using UnityEngine;

[Serializable] public struct Email
{
    [SerializeField] private string _from, _to;
    [SerializeField] private string _header;
    [SerializeField, TextArea(3, 3)] private string _body;

    public string To { set => _to = value; }
    public string Body { set => _body = value; }
    public MailMessage Message => new MailMessage(_from, _to, _header, _body);
    public bool IsNullOrEmpty => string.IsNullOrEmpty(_from) || string.IsNullOrEmpty(_to);
}