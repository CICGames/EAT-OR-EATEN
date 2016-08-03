using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkInitializer : NetworkManager {

    private float _loadingGauge = 0f;
    private NetworkConnection _conn;
    private short _playerControllerId;

    void Start() {
        NetworkManager.singleton.networkAddress = GlobalData.SERVER_IP;
        NetworkManager.singleton.networkPort = GlobalData.PORT;
        
        if (!IsServer()) { // 서버이면 서버 오픈
            OpenServer();
        } else {
            ConnectToServer();
        }
    }



    public override void OnClientConnect(NetworkConnection _conn) {
        _loadingGauge = 1f;
        //if (SceneManager.GetActiveScene().name.Equals(GlobalData.INTRO_SCENE))
            ServerChangeScene(GlobalData.MAIN_SCENE);
        
    }

    // 클라이언트의 연결이 끊겼을 경우 발생
    //public override void OnClientDisconnect(NetworkConnection _conn) {

    //}

    private bool IsServer() {
        return Network.player.ipAddress.Equals(GlobalData.SERVER_IP);
    }

    private void OpenServer() {
        StartHost();
    }

    public void ConnectToServer() {
        CheckInternetOpen(); // 인터넷이 되는지 확인
        CheckUpdate(); // 업데이트 체크
        GetUserInfomation(); // 사용자 정보 가져오기

        if (!NetworkClient.active) {
            StartClient();
        }

    }

    // 서버가 열려있는지 체크
    void CheckInternetOpen() {
        if (isNetworkActive) {
            Debug.Log("No Internet");
            return;
        }

        _loadingGauge = 0.2f;
    }

    // 업데이트 체크 q
    private bool CheckUpdate() {
        _loadingGauge = 0.5f;
        return true;
    }

    // 사용자 정보 가져오기
    private bool GetUserInfomation() {
        _loadingGauge = 0.7f;
        return true;
    }

    public void CheckFinished(int _progressBar) {
        Debug.Log(_progressBar);
    }

    public void GameStart() {
        //NetworkServer.Spawn(playerPrefab);
        //GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        //       NetworkServer.Spawn(player);
    }

    // 플레이어 추가하기
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
        //  base.OnServerAddPlayer(conn, playerControllerId);

        
        // 플레이어 케릭터 정보 가져온 후 여기서 추가하자.
        this._playerControllerId = playerControllerId;
        GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }


    public NetworkConnection GetNetworkConnection() { return _conn; }
    public float GetLoadingGauge() { return _loadingGauge; }
    public short GetPlayerControlId() { return _playerControllerId; }

    public void PlayerSpawn() {
        ClientScene.AddPlayer(0);
    }
}
