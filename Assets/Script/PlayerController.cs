using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;

public class PlayerController : Character{

    public GameObject _playerCamera;
    //public GameObject _defaultAttack;
    public float _defaultMoveSpeed;

    GameObject _aiming;

    bool _cannonState = false;
    float _nextAttackRate = 0.0f;

    //기본공격
    GameObject _skillDefault;

    //스킬 3개 선택 했을 시 Start에서 넣어줘야함.
    GameObject _skill_1;
    GameObject _skill_2;
    GameObject _skill_3;

    [SerializeField] private Rigidbody _myRigidbody;
    [SerializeField] MeshCollider _meshCollider;

    // Use this for initialization
    void Start() {
        _skillDefault = _skill_Default_Level1;

        if (isLocalPlayer) {
            _playerCamera = Instantiate<GameObject>(_playerCamera);
            _playerCamera.GetComponent<CameraController>().SetPlayer(transform);
            _playerCamera.GetComponent<AudioListener>().enabled = true;

            _aiming = transform.GetChild(0).GetChild(0).gameObject;
        }
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

        float moveSpeed = _defaultMoveSpeed;

        if (Input.GetKey(KeyCode.W))
            _myRigidbody.AddForce(Vector3.forward * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.S))
            _myRigidbody.AddForce(-Vector3.forward * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.A))
            _myRigidbody.AddForce(-Vector3.right * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.D))
            _myRigidbody.AddForce(Vector3.right * Time.deltaTime * moveSpeed);


        //항상 마우스를 조준함
        Vector3 _mouseWorld = ClickPoint(Input.mousePosition,_playerCamera);
        //마우스 클릭 좌표와 플레이어 좌표의 Y축을 동일하게 정해줌.
        _mouseWorld.y = transform.position.y;
        _aiming.transform.LookAt(_mouseWorld);

        //  Debug.Log("Player: " + transform.position + ", Mouse: " + _mouseWorld + "Input: " + Input.mousePosition);

        if (_cannonState) {
            LoadCannon();
        } else {
            UnloadCannon();
        }

        if (Input.GetMouseButton(0)) {
            //공격속도
            if(Time.time > _nextAttackRate) {
                _nextAttackRate = Time.time + _attackSpeed;
                _cannonState = true;
                CmdDefaultAttack(_skillDefault);
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            _cannonState = false;
        }


            //Attack(_mouseWorld,_defaultAttack);
    }
}
