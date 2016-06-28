using UnityEngine;
using System.Collections;

public class EffectDefaultLevel1 : MonoBehaviour {

    public static bool _test = false;
    public float _lerpRate;

    private Vector3 _defaultPosition;
    Vector3 _parent;

    // Use this for initialization
    void Start () {
        _parent = new Vector3(0, 0, 2f);
        _defaultPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        // 기본상태일때 효과 안보이게 해야함.
        // 공격이 완료 되었을때 _test가 false가 되며 기본 위치로 이동 시켜야함.
        if (_test) {
         //   gameObject.SetActive(true);
            transform.localPosition = Vector3.Lerp(transform.localPosition, _parent, Time.deltaTime * _lerpRate);
        } else {
            transform.localPosition = _defaultPosition;
           // gameObject.SetActive(false);
        }
    }
}
