﻿using UnityEngine;
using System.Collections;

public class SatelliteRotator : MonoBehaviour {

    public float orbitSpeed;

    public float rotateRate;
    public float InvokeRate;

    float xRot;
    float yRot;
    float zRot;
    float wRot;

    // Use this for initialization
    void Start () {
        InvokeRepeating("newRotation", 0.0f, InvokeRate);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(new Vector3(15, 30, 45) * orbitSpeed * Time.deltaTime);
        Quaternion RandomQuat = new Quaternion(xRot, yRot, zRot, wRot);
        transform.rotation = Quaternion.Slerp(transform.rotation, RandomQuat, rotateRate * Time.deltaTime);
    }

    void newRotation() {
        xRot = Random.Range(-720, 720);
        yRot = Random.Range(-720, 720);
        zRot = Random.Range(-720, 720);
        wRot = Random.Range(-720, 720);
    }
}
