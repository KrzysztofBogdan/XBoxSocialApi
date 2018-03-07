using UnityEngine;
using UnityEngine.UI;

public class DebugLogPrint : MonoBehaviour
{
    public Text Text;

    private void OnEnable()
    {
        Application.logMessageReceived += OnLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= OnLog;
    }

    private void OnLog(string message, string stacktrace, LogType type)
    {
        Text.text += message + "\n";
    }
}