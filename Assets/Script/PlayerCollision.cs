using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System;

public class PlayerCollision : MonoBehaviour {

    List<GameObject> _feeds;
    float _pickupsLerpSpeed = 0.5f;  // 먹이 먹었을때 구체 중심쪽으로 들어가는 속도

    // Use this for initialization
    void Start() {
        _feeds = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {

        //먹이 먹었을때 빨려들어가는 이벤트
        if (_feeds.Count != 0) {
            for (int i = 0; i < _feeds.Count; i++) {
                if (_feeds[i] != null) {
                    _feeds[i].transform.position = Vector3.Lerp(_feeds[i].transform.position, transform.position, _pickupsLerpSpeed * Time.deltaTime);
                    var _distance = Vector3.Distance(transform.position, _feeds[i].transform.position); //위치 구하기.
                    if (_distance < 0.1) {
                        _feeds[i].SetActive(false);
                        float _size = (float)(transform.localScale.x + (_feeds[i].transform.lossyScale.x / 10));
                        transform.localScale = new Vector3(_size, _size, _size);
                        GameObject _tmp = _feeds[i];
                        _feeds.Remove(_feeds[i]);
                        Destroy(_tmp);
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider _other) {
        if (_other.gameObject.CompareTag("Feed_Square")) {
            _other.transform.parent = transform;
            _feeds.Add(_other.gameObject);
        }
    }
}
