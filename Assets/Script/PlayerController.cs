using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class PlayerController : Character {

    //발사 위치!
    public Transform _skill_Default_Spawn;

    public GameObject _playerCamera;
    
    //기본공격 컴포넌트 저장할 곳
    ISkill _Idefaultattack;
    public GameObject _attackObject;
    
    //공속
    float _nextAttackRate = 0.0f;

    [SerializeField]
    Transform _aiming;
    [SerializeField]
    private Rigidbody _myRigidbody;
    [SerializeField]
    MeshCollider _meshCollider;

    // Use this for initialization
    void Start() {
        if (NetworkServer.active)
            Debug.Log("Actived");
        else
            Debug.Log("DeActived");

        if (isLocalPlayer) {
            _playerCamera = Instantiate<GameObject>(_playerCamera);
            _playerCamera.GetComponent<CameraController>().SetPlayer(transform);
            _playerCamera.GetComponent<AudioListener>().enabled = true;
            //_defaultattack = Instantiate<GameObject>(_defaultattack);
            //컴포넌트 갖고오기
            //_Idefaultattack = _defaultattack.GetComponent<SphereSkillDefault>();


            //초기화 해줘서 Charactor를 넣어줌(값 공유목적).
            //_Idefaultattack.initiate(this);


            _attackObject = Instantiate<GameObject>(_attackObject);
        }

        //_healthbar.GetComponent<Image>().fillAmount = _currentHealth / _maxHealth;
        InitHealth();
        _Idefaultattack = _attackObject.GetComponent<SphereSkillDefault>();
        _Idefaultattack.initiate(this);
    }

    void OnDestroy() {
        if (isLocalPlayer) {
            Destroy(_playerCamera);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!isLocalPlayer) {
            return;
        }

        float moveSpeed = GetMoveSpeed();

        if (Input.GetKey(KeyCode.W))
            _myRigidbody.AddForce(Vector3.forward * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.S))
            _myRigidbody.AddForce(-Vector3.forward * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.A))
            _myRigidbody.AddForce(-Vector3.right * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.D))
            _myRigidbody.AddForce(Vector3.right * Time.deltaTime * moveSpeed);


        //항상 마우스를 조준함
        Vector3 _mouseWorld = ClickPoint(Input.mousePosition, _playerCamera);

        //마우스 클릭 좌표와 플레이어 좌표의 Y축을 동일하게 정해줌.
        _mouseWorld.y = transform.position.y;
        _aiming.transform.LookAt(_mouseWorld);

        //  Debug.Log("Player: " + transform.position + ", Mouse: " + _mouseWorld + "Input: " + Input.mousePosition);

        if (Input.GetMouseButton(0)) {

            //공격속도
            if (Time.time > _nextAttackRate) {
                _nextAttackRate = Time.time + GetAttackSpeed();
                CmdAtack();
            }
        } else {

        }
    }
    
    [Command]
    public void CmdAtack() {
        _Idefaultattack.CmdAttack();
    }
}
