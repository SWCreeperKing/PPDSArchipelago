using System;
using System.IO;
using PPDSAP.Patches;
using UnityEngine;

namespace PPDSAP;

// stolen from: https://github.com/FyreDay/TCG-CardShop-Sim-APClient/blob/master/APGui.cs
public class APGui : MonoBehaviour
{
    public static bool ShowGUI = true;
    public static string Ipporttext = "archipelago.gg:12345";
    public static string Password = "";
    public static string Slot = "Duck";
    public static string State = "";
    public static Vector2 Offset = Vector2.zero;

    public static GUIStyle TextStyle = new()
    {
        fontSize = 12,
        normal =
        {
            textColor = Color.white
        }
    };

    public static GUIStyle TextStyleGreen = new()
    {
        fontSize = 12,
        normal =
        {
            textColor = Color.green
        }
    };

    public static GUIStyle TextStyleRed = new()
    {
        fontSize = 12,
        normal =
        {
            textColor = Color.red
        }
    };

    private void Awake()
    {
        if (!File.Exists("ApConnection.txt")) return;
        var fileText = File.ReadAllText("ApConnection.txt").Replace("\r", "").Split('\n');
        Ipporttext = fileText[0];
        Password = fileText[1];
        Slot = fileText[2];
    }

    void OnGUI()
    {
        if (!ShowGUI) return;

        // Create a GUI window
        GUI.Box(new Rect(10 + Offset.x, 10 + Offset.y, 200, 300), "AP Client");

        // Set font size and color

        // Display text at position (10,10)
        GUI.Label(new Rect(20 + Offset.x, 40 + Offset.y, 300, 30), "Address:port", TextStyle);
        Ipporttext = GUI.TextField(new Rect(20 + Offset.x, 60 + Offset.y, 180, 25), Ipporttext, 25);

        GUI.Label(new Rect(20 + Offset.x, 90 + Offset.y, 300, 30), "Password", TextStyle);
        Password = GUI.TextField(new Rect(20 + Offset.x, 110 + Offset.y, 180, 25), Password, 25);

        GUI.Label(new Rect(20 + Offset.x, 140 + Offset.y, 300, 30), "Slot", TextStyle);
        Slot = GUI.TextField(new Rect(20 + Offset.x, 160 + Offset.y, 180, 25), Slot, 25);

        if (!ApDuckClient.IsConnected() && GUI.Button(new Rect(20 + Offset.x, 210 + Offset.y, 180, 30), "Connect"))
        {
            var ipPortSplit = Ipporttext.Split(':');
            if (!int.TryParse(ipPortSplit[1], out var port))
            {
                State = $"[{ipPortSplit[1]}] is not a valid port";
                return;
            }

            var error = ApDuckClient.TryConnect(port, Slot, ipPortSplit[0], Password);

            if (error is not null)
            {
                State = string.Join("\n", error);
                return;
            }

            State = "";
            File.WriteAllText("ApConnection.txt", $"{Ipporttext}\n{Password}\n{Slot}");
        }

        if (ApDuckClient.IsConnected() && GUI.Button(new Rect(20 + Offset.x, 210 + Offset.y, 180, 30), "Disconnect"))
        {
            ApDuckClient.Disconnect();
        }

        GUI.Label(new Rect(20 + Offset.x, 240 + Offset.y, 300, 30),
            State != "" ? State : ApDuckClient.IsConnected() ? "Connected" : "Not Connected",
            ApDuckClient.IsConnected() ? TextStyleGreen : TextStyleRed);
    }

    private void Update()
    {
        ApDuckClient.Update(null);
        MainMenuPatch.NewGame.SetActive(ApDuckClient.IsConnected());
    }
}