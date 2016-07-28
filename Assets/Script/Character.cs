using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Character : NetworkBehaviour {

    public RectTransform _healthbar;

    protected float _attackSpeed = 0.5f;

    protected float _maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")] protected float _currentHealth = 100;

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
            Debug.Log("you are dead !");
        }

    }

    void OnChangeHealth(float health) {
        _healthbar.GetComponent<Image>().fillAmount = health / _maxHealth;
    }

    //대포 앞으로 움직임.

    //protected void LoadCannon() {
    //    _skill_Default_Cannon.GetComponent<MeshRenderer>().enabled = true;
    //    _skill_Default_Cannon.transform.localPosition = Vector3.Lerp(_skill_Default_Cannon.transform.localPosition, new Vector3(0,0,1), Time.deltaTime * 13f);
    //}

    //protected void UnloadCannon() {
    //    _skill_Default_Cannon.transform.localPosition = Vector3.Lerp(_skill_Default_Cannon.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 10f);
    //    if(_skill_Default_Cannon.transform.localPosition.z == 0)
    //      _skill_Default_Cannon.GetComponent<MeshRenderer>().enabled = false;
    //}

}
