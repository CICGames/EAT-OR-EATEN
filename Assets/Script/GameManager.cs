using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    public NetworkInitializer _networkInitializer;
    public GameObject _player;

    public void GameStart() {
        ClientScene.AddPlayer(_networkInitializer.client.connection, _networkInitializer.GetPlayerControlId());
    }
}
