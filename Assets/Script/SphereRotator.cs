using UnityEngine;
using System.Collections;

public class SphereRotator : MonoBehaviour {

    int _speed;

    Vector3 _direction;


    void Start() {
        _speed = Random.Range(100, 180);
        float angle = Vector3.Angle(new Vector3(1, 0, 0), transform.position);
        if (transform.localPosition.y < 0) { 
            angle *= -1;
        }
        if (transform.localPosition.x < 0) {
            angle *= -1;
        }
        Debug.Log(angle);
        _direction = new Vector3(angle*2, 360, 0);
    }


    void Update() {
        transform.RotateAround(transform.parent.position, _direction, _speed *Time.deltaTime);
    }
}
