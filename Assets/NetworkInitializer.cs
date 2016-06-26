using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkInitializer : MonoBehaviour {

    public GameObject _player;
    public NetworkManager _networkManager;

    private const string SERVER_IP = "192.168.0.30";
    private const int SERVER_PORT = 7777;
    private bool _useNat = true;

    void Start() {
        _networkManager = GetComponent<NetworkManager>();

        _networkManager.networkAddress = SERVER_IP;
        _networkManager.networkPort = SERVER_PORT;
    }

    void OnGUI() {
        if (!NetworkServer.active && !NetworkClient.active)  {
            if (GUI.Button(new Rect(20, 20, 200, 25), "Start Server")) {
                //Network.InitializeServer(20, SERVER_PORT, _useNat);
                //_networkManager.StartServer();
                _networkManager.StartHost();
            }

            if (GUI.Button(new Rect(20, 50, 200, 25), "Connect to Server")) {
                //Network.Connect(SERVER_IP, SERVER_PORT);
                _networkManager.StartClient();
            }
        } else {
            if(NetworkServer.active) {
                GUI.Label(new Rect(20, 20, 200, 25), "Initailization Server...");
                GUI.Label(new Rect(20, 50, 200, 25), "Client Count = " + NetworkClient.allClients.Count);
            }

            if (NetworkClient.active) {
                GUI.Label(new Rect(20, 20, 200, 25), "Connect to Server");
            }
        }
    }

    void OnServerInitialized() {
        CreatePlayer();
    }

    void OnConnectedToServer() {
        CreatePlayer();
    }

    void CreatePlayer() {
        ;
        //Vector3 _position = new Vector3(5f, 0f, 5f);
        //Network.Instantiate(_player, _position, Quaternion.identity, 0);
        ////GameObject test = (GameObject)Instantiate(_player, _position, Quaternion.identity);

        ////NetworkServer.Spawn((GameObject)Instantiate(_player, _position, Quaternion.identity));
    }

}
