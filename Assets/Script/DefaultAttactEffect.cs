using UnityEngine;
using System.Collections;

public class DefaultAttactEffect : MonoBehaviour {

    public static bool test = false;
    public float lerpRate;

    private Vector3 defaultposition;
    Vector3 parents;

    // Use this for initialization
    void Start () {
        parents = new Vector3(0, 0, 1.2f);
        defaultposition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if (test) {
         //   gameObject.SetActive(true);
            transform.localPosition = Vector3.Lerp(transform.localPosition, parents, Time.deltaTime * lerpRate);
        } else {
            transform.localPosition = defaultposition;
           // gameObject.SetActive(false);
        }
    }
}
