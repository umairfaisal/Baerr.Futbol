using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
//using WebSocketSharp;

public class NetworkCore : MonoBehaviour
{
   /* public Transform player;

    // Interval for sending location updates
    public float updateInterval = 0.5f;
    private float timeSinceLastUpdate = 0f;
    private WebSocket ws;

    void Start()
    {
        ConnectToServer();
    }

    private void ConnectToServer()
    {
        string serverUrl = "ws.abcasdf.com:port";

        ws = new WebSocket(serverUrl);

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("Connection Established");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message received from server" + e.Data);

        };

        ws.OnError += (sender, e) =>
        {
            Debug.LogError("WebSocket Error: " + e.Message);
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("Connection closed: " + e.Reason);
        };

        ws.Connect();
    }

    public void SendMessageToServer(string message)
    {
        if (ws != null && ws.IsAlive)
        {
            ws.Send(message);
            Debug.Log("Message sent to server: " + message);
        }
        else
        {
            Debug.LogError("WebSocket is not connected.");
        }
    }

    private void OnApplicationQuit()
    {
        if (ws != null)
        {
            ws.Close();
        }
    }

    void Update()
    {
        if (ws != null && ws.IsAlive && player != null)
        {
            timeSinceLastUpdate += Time.deltaTime;
            if (timeSinceLastUpdate >= updateInterval)
            {
                SendPlayerLocation();
                timeSinceLastUpdate = 0f;
            }
        }
    }

    private void SendPlayerLocation()
    {
        Vector2 position = player.position;
        Vector2 rotation = player.eulerAngles;

        // Create a JSON string with player data
        string message = JsonUtility.ToJson(new PlayerData
        {
            position = new Vector3Data(position),
            rotation = new Vector3Data(rotation)
        });

        //ws.Send(message);
        //Debug.Log("Player location sent to server: " + message);
    }

    [System.Serializable]
    public class PlayerData
    {
        public Vector3Data position;
        public Vector3Data rotation;
    }

    [System.Serializable]
    public class Vector3Data
    {
        public float x;
        public float y;
        public float z;

        public Vector3Data(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }
    }
   */
}
    

    
