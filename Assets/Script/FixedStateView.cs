using UnityEngine;

public class FixedStateView : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(new Vector3(90f, 0, 0));
    }
}
