using UnityEngine;

public class FixedLocalRotate : MonoBehaviour {

    public Camera localcamera;
    
	// Update is called once per frame
	void Update () {
        transform.LookAt(localcamera.transform);
    }
}
