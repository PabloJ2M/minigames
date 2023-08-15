using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SaveExcel : MonoBehaviour
{
    private static string _fileName = "datos";

    public static async void Set(string[] datos)
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string path = Path.Combine(desktop, $"{ _fileName }.csv");

        string content = string.Empty;
        if (File.Exists(path)) content = File.ReadAllText(path);

        await Task.Yield();

        StringBuilder sb = new StringBuilder(content);
        string row = string.Join(",", datos);
        sb.AppendLine(row);

        print($"data saved in path: {path}");
        File.WriteAllText(path, sb.ToString());
    }
    public static string[] Get()
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string path = Path.Combine(desktop, $"{_fileName}.csv");

        if (!File.Exists(path)) return null;
        return File.ReadAllText(path).Split(",");
    }
}