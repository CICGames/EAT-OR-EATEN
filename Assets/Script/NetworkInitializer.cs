using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkInitializer : NetworkManager {

    private float _loadingGauge = 0f;
    private NetworkConnection _conn;

    void Start() {
        NetworkManager.singleton.networkAddress = GlobalData.SERVER_IP;
        NetworkManager.singleton.networkPort = GlobalData.PORT;

        if (IsServer()) { // 서버이면 서버 오픈
            OpenServer();
        } else {
            ConnectToServer();
        }
    }
    
    
    
    public override void OnClientConnect(NetworkConnection _conn) {
        base.OnClientConnect(_conn);
        this._conn = _conn;

        // 씬 변경
        if (SceneManager.GetActiveScene().name.Equals(GlobalData.INTRO_SCENE))
            SceneManager.LoadScene(GlobalData.MAIN_SCENE, LoadSceneMode.Single);
    }

    // 클라이언트의 연결이 끊겼을 경우 발생
    public override void OnClientDisconnect(NetworkConnection _conn) {
        
    }

    private bool IsServer() {
        return Network.player.ipAddress.Equals(GlobalData.SERVER_IP);
    }

    private void OpenServer() {
        StartHost();
        //StartServer();
    }
    
    public void ConnectToServer() {
        CheckServerOpen(); // 서버가 열려있는지 체크
        CheckUpdate(); // 업데이트 체크
        GetUserInfomation(); // 사용자 정보 가져오기

        if (!NetworkClient.active) {
            StartClient();
        }
        
    }

    // 서버가 열려있는지 체크
    void CheckServerOpen() {
        if (!NetworkServer.active) {
            Debug.Log("Server is not Open");
            return;
        }

        _loadingGauge = 0.2f;
    }

    // 업데이트 체크
    private bool CheckUpdate() {
        _loadingGauge = 0.5f;
        return true;
    }

    // 사용자 정보 가져오기
    private bool GetUserInfomation() {
        return true;
    }

    public void CheckFinished(int _progressBar) {
        Debug.Log(_progressBar);
    }

    public void GameStart() {
            GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            //NetworkServer.Spawn(player);
    }


    public NetworkConnection GetNetworkConnection() { return _conn; }
    public float GetLoadingGauge() { return _loadingGauge; }
    
}
