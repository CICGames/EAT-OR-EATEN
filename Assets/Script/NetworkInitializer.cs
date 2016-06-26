using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkInitializer : MonoBehaviour {

    public GameObject _player;
    public NetworkManager _networkManager;
    
    void Start() {
        _networkManager = GetComponent<NetworkManager>();

        _networkManager.networkAddress = GlobalData.SERVER_IP;
        _networkManager.networkPort = GlobalData.PORT;
    }

    void OnGUI() {
        if (!NetworkServer.active && !NetworkClient.active)  {
            if (GUI.Button(new Rect(20, 20, 200, 25), "Start Server")) {
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
}
