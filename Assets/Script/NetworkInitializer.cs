using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;
using System.Net;

public class NetworkInitializer : MonoBehaviour {

    public GameObject _player;
    public NetworkManager _networkManager;

    private float _loadingGauge = 0f;

    void Start() {
        _networkManager = GetComponent<NetworkManager>();

        _networkManager.networkAddress = GlobalData.SERVER_IP;
        _networkManager.networkPort = GlobalData.PORT;

        if (!IsServer()) {
            OpenServer();
        } else {
            if (CheckState()) {
                _loadingGauge = 1f; // 모든 설정 완료
            }
        }
        
    }

    private bool IsServer() {
        return Network.player.ipAddress.Equals(GlobalData.SERVER_IP);
    }

    private void OpenServer() {
        _networkManager.StartHost();
        //_networkManager.StartServer();
    }

    public bool CheckState() {
        CheckServerOpen();
        CheckUpdate();

        return true;
    }
    
    public void Connect() {
        if (!NetworkClient.active) {
            _networkManager.StartClient();
        }
        
    }

    

    // Update Check
    void CheckUpdate() {
        _loadingGauge = 0.5f;
    }

    public void CheckFinished(int _progressBar) {
        Debug.Log(_progressBar);
    }

    // Server Check
    void CheckServerOpen() {
        if (!NetworkServer.active) {
            Debug.Log("Server is not Open");
            return;
        }

        _loadingGauge = 0.2f;
    }

    public float GetLoadingGauge() { return _loadingGauge; }
    
}
