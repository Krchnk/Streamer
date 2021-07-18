using UnityEngine;
using WebSocketSharp;

public class Sender : MonoBehaviour
{
    private WebSocket _websocket;

    private void Start()
    {
        _websocket = new WebSocket("ws://zmapp.ru:9999/media/playerControl");
        _websocket.Connect();
        _websocket.OnMessage += _websocket_OnMessage;
        _websocket.OnError += _websocket_OnError;

        string changeArea = "{ \"operation\": \"set_area_id\", \"area_id\": 24  }";
        string streamLink = "{ \"operation\":\"setAreaStream\", \"streamLink\":\" 2 \"}";
        string availableAreas = "{\"operation\": \"getAreaList\"}";

        _websocket.Send(availableAreas);
        _websocket.Send(changeArea);
        _websocket.Send(streamLink);

    }

    private void _websocket_OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log(e.Message);
    }

    private void _websocket_OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);
    }
}
