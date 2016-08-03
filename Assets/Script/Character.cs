using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Character : NetworkBehaviour {

    public RectTransform _healthbar;

    public GameObject _debris;

    
    //protected float _attackSpeed = 0.5f;

    // 케릭터 스텟
    private float _strength;
    private float _physical;
    private float _dex;
    private float _luc;

    // 케릭터 능력치
    private float _attackPower = 20f;
    private float _attackSpeed = 1f; 
    private float _defensePower = 100f;
    private float _moveSpeed = 15;
    private float _maxHealth = 100f;
    [SyncVar(hook = "OnChangeHealth")] private float _currentHealth = 100f;
    private float _recoveryRate = 1f; // %
    private float _criticalRate = 0.01f; // %
    private float _criticalPower = 0.2f; // %
    private float _evasionRate = 0.01f; // %


    //Get mouse click point
    protected Vector3 ClickPoint(Vector3 _mousePosition, GameObject _playerCamera) {

        _mousePosition.z = GlobalData.MOUSE_POSITION_Z;

        return _playerCamera.GetComponent<Camera>().ScreenToWorldPoint(_mousePosition);
    }

    //체력 설정. 기본 체력 100인데 체력 능력치 찍으면 따라서 올라야 하기때매 추가해둠. 
    protected void SetHealth(int _maxHealth) {
        this._maxHealth = _maxHealth;
    }

    //데미지 입는부분
    public void TakeDamage(int amout) {
        if (!isServer)
            return;

        _currentHealth -= amout;

        if (_currentHealth <= 0) {
            _currentHealth = 0;
            DeathMotion();
        }

    }

    void OnChangeHealth(float health) {
        _healthbar.GetComponent<Image>().fillAmount = health / _maxHealth;
    }

    public void InitHealth() {
        _healthbar.GetComponent<Image>().fillAmount = _currentHealth / _maxHealth;
    }

    public float GetAttackSpeed() { return _attackSpeed; }
    public float GetMoveSpeed() { return _moveSpeed; }


    protected void DeathMotion() {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        for (int i = 0; i < 30; i++) {
            Vector3 v = new Vector3(x + Random.Range(-0.1f, 0.1f), y + Random.Range(0, 0.1f), z + Random.Range(-0.1f, 0.1f));
            GameObject gameobject = (GameObject)Instantiate(_debris, v, Quaternion.identity);
            gameobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            NetworkServer.Spawn(gameobject);
        }
        Destroy(gameObject);
    }

}
