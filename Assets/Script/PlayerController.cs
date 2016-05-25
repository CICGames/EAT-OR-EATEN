using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
    float speed;
    private Rigidbody rb;
    MeshCollider meshcollider;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        meshcollider = GetComponent<MeshCollider>();
        speed = 500f;
    }

    // Update is called once per frame
    void Update() {

        if (!isLocalPlayer) {
            return;
        }

        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-Vector3.forward * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-Vector3.right * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * Time.deltaTime * speed);

    }
}
