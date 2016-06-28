using UnityEngine;
using UnityEngine.Networking;

public class Character : NetworkBehaviour {

    public GameObject _skill_Default_Level1;
    public GameObject _skill_Default_Cannon;
    public Transform _skill_Default_Spawn;

    protected float _attackSpeed = 0.5f;

    protected int _maxHealth = 100;
    protected int _currentHealth = 100;

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
    protected void TakeDamage(int amout) {
        _currentHealth -= amout;

        if(_currentHealth <= 0) {
            _currentHealth = 0;
            Debug.Log("you are dead !");
        }
    }

    //대포 앞으로 움직임.
    protected void LoadCannon() {
        _skill_Default_Cannon.GetComponent<MeshRenderer>().enabled = true;
        _skill_Default_Cannon.transform.localPosition = Vector3.Lerp(_skill_Default_Cannon.transform.localPosition, new Vector3(0,0,1), Time.deltaTime * 13f);
    }

    protected void UnloadCannon() {
        _skill_Default_Cannon.transform.localPosition = Vector3.Lerp(_skill_Default_Cannon.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 10f);
        if(_skill_Default_Cannon.transform.localPosition.z == 0)
          _skill_Default_Cannon.GetComponent<MeshRenderer>().enabled = false;
    }

    //기본 공격 함수. _attackObject에 넣는거 날아감.
    [Command]
    protected void CmdDefaultAttack(GameObject _attackObject) {

        GameObject bullet = (GameObject)Instantiate(_attackObject,_skill_Default_Spawn.position, _skill_Default_Spawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2);
    }


    //원래 있던 파랑스킬 공격함수. 일단 놔둠
    protected void Attack(Vector3 _attackPoint, GameObject _defaultAttack) {
        GameObject _at = Instantiate<GameObject>(_defaultAttack);
        _at.GetComponent<SkillDefaultLevel1>().SetAttackPoint(transform.position, _attackPoint);
    }
}
