using UnityEngine;
using System.Collections;

public class SatelliteRotator : MonoBehaviour {

    public float orbitSpeed;

    public float _rotateRate;
    public float _invokeRate;
    float _xRot;
    float _yRot;
    float _zRot;
    float _wRot;

    // Use this for initialization
    void Start () {
        InvokeRepeating("newRotation", 0.0f, _invokeRate);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(new Vector3(15, 30, 45) * orbitSpeed * Time.deltaTime);
        Quaternion _RandomQuat = new Quaternion(_xRot, _yRot, _zRot, _wRot);
        transform.rotation = Quaternion.Slerp(transform.rotation, _RandomQuat, _rotateRate * Time.deltaTime);
    }

    void newRotation() {
        _xRot = Random.Range(-720, 720);
        _yRot = Random.Range(-720, 720);
        _zRot = Random.Range(-720, 720);
        _wRot = Random.Range(-720, 720);
    }
}
