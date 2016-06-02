using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();

    }

    void Update() {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetType() == typeof(TerrainCollider)) {
            if (!other.CompareTag("Pickup1")) {
                (gameObject.GetComponent(typeof(SphereCollider)) as Collider).enabled = false;
                rb.useGravity = false;
                rb.isKinematic = true;
            }
        }
    }
}

