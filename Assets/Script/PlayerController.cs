using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;

public class PlayerController : Character{

    public GameObject _playerCamera;
    public GameObject _defaultAttack;
    public float _defaultMoveSpeed;
    GameObject _aiming;

    [SerializeField] private Rigidbody _myRigidbody;
    [SerializeField] MeshCollider _meshCollider;

    // Use this for initialization
    void Start() {
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

        if (Input.GetMouseButtonDown(0)) {
            Vector3 _mouseWorld = ClickPoint(Input.mousePosition,_playerCamera);

            Debug.Log("Player: " + transform.position + ", Mouse: " + _mouseWorld + "Input: " + Input.mousePosition);


            //공격 효과 실행
            EffectDefaultLevel1._test = true;

            //마우스 클릭 포인트로 sphere들 조준(이동)
            _aiming.transform.LookAt(_mouseWorld);

            Attack(_mouseWorld);
        }
        if (Input.GetMouseButtonDown(1)) {
            EffectDefaultLevel1._test = false;
            ;
        }
    }

    public void Attack(Vector3 _attackPoint) {
        GameObject _at = Instantiate<GameObject>(_defaultAttack);
        _at.GetComponent<SkillDefaultLevel1>().SetAttackPoint(transform.position, _attackPoint);
        
    }
}
