using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TestStartScript : MonoBehaviour {

    private GameObject manager;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("Network Manager");
	}

    public void GameStart() {
        manager.GetComponent<NetworkInitializer>().PlayerSpawn();
    }
	
}
