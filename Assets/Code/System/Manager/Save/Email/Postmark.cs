using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;

[Serializable] public struct Postmark
{
    [SerializeField] private string _url;
    [SerializeField] private string _api;

    [Header("SMTP")]
    [SerializeField] private string _host;
    [SerializeField] private int _port;

    [Header("Server")]
    [SerializeField] private string _username;
    [SerializeField] private string _password;

    public string URL => _url;
    public string API => _api;
    public SmtpClient SMTP => new SmtpClient(_host, _port);
    public NetworkCredential Credentials => new NetworkCredential(_username, _password);
}