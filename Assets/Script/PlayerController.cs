using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;

public class PlayerController : NetworkBehaviour {

    public GameObject playerCamera;
    public GameObject defaultAttack;
    public float defaultMoveSpeed;

    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] MeshCollider meshcollider;

    // Use this for initialization
    void Start() {
        if (isLocalPlayer) {
            playerCamera = Instantiate<GameObject>(playerCamera);
            playerCamera.GetComponent<CameraController>().SetPlayer(transform);
            playerCamera.GetComponent<AudioListener>().enabled = true;
        }
    }

    void OnDestroy() {
        if (isLocalPlayer) {
            Destroy(playerCamera);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!isLocalPlayer) {
            return;
        }

        float moveSpeed = defaultMoveSpeed;

        if (Input.GetKey(KeyCode.W))
            myRigidbody.AddForce(Vector3.forward * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.S))
            myRigidbody.AddForce(-Vector3.forward * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.A))
            myRigidbody.AddForce(-Vector3.right * Time.deltaTime * moveSpeed);
        if (Input.GetKey(KeyCode.D))
            myRigidbody.AddForce(Vector3.right * Time.deltaTime * moveSpeed);

        if (Input.GetMouseButtonDown(0)) {
            Vector3 cc = Input.mousePosition;
            cc.z = 4f;



            Vector3 mouseWorld = playerCamera.GetComponent<Camera>().ScreenToWorldPoint(cc);
            mouseWorld.y = 0.3f;
            //mouseWorld.z += mouseWorld.y;
            //mouseWorld.y = 0;
            Debug.Log("Player: " + transform.position + ", Mouse: " + mouseWorld + "Input: " + Input.mousePosition);
            Attack(mouseWorld);
        }
    }

    public void Attack(Vector3 attackPoint) {
        GameObject at = Instantiate<GameObject>(defaultAttack);
        at.GetComponent<TestAttact>().SetAttackPoint(transform.position, attackPoint);
        
    }
}
