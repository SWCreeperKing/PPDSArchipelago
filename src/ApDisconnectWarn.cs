using UnityEngine;

namespace PPDSAP;

public class ApDisconnectWarn : MonoBehaviour
{
    public static GUIStyle TextStyle = new()
    {
        fontSize = 32,
        normal =
        {
            textColor = Color.red
        }
    };

    private void OnGUI()
    {
        GUI.Box(new Rect(140, 245, 150, 35), "Duck Spawn Timer");
        GUI.Label(new Rect(175, 265, 75, 30),
            $"{ApDuckClient.Timer:###,##0.00}s / {120 - ApDuckClient.SpeedCount * 10}s", APGui.TextStyle);

        if (ApDuckClient.IsConnected()) return;
        GUI.Box(new Rect(140, 140, 610, 105), "Ap Disconnection Warn Box");
        GUI.Label(new Rect(145, 165, 240, 30), "DISCONNECTED FROM ARCHIPELAGO", TextStyle);
        GUI.Label(new Rect(145, 205, 240, 30), "PLEASE SAVE AND RELOAD SAVE", TextStyle);
    }
}