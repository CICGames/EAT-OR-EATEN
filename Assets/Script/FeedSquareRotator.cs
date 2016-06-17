using UnityEngine;
using System.Collections;

public class FeedSquareRotator : MonoBehaviour {

    Rigidbody _rigidBody;

    void Start() {
        _rigidBody = GetComponent<Rigidbody>();

    }

    void Update() {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider _other) {
        if (_other.GetType() == typeof(TerrainCollider)) {
            if (!_other.CompareTag("Feed_Square")) {
                //(gameObject.GetComponent(typeof(SphereCollider)) as Collider).enabled = false;
                _rigidBody.useGravity = false;
                _rigidBody.isKinematic = true;
            }
        }
    }
}

