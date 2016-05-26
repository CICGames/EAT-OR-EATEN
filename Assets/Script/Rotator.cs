using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    int pickup_count = 0;
    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}

