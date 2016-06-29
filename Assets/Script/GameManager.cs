using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    public NetworkInitializer _networkInitializer;
    public GameObject _player;

    void Start() {
        Debug.Log(isLocalPlayer);
    }

    public void GameStart() {
        Debug.Log(isLocalPlayer);
        //GameObject player = (GameObject)Instantiate(_networkInitializer.playerPrefab, Vector3.zero, Quaternion.identity);

        ////NetworkServer.Spawn(player

    }
}
