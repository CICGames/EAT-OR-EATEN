using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System;

public class PlayerCollision : MonoBehaviour {

    List<GameObject> feed;
    float pickups_lerp_speed = 0.5f;  // 먹이 먹었을때 구체 중심쪽으로 들어가는 속도

    // Use this for initialization
    void Start() {
        feed = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {

        //먹이 먹었을때 빨려들어가는 이벤트
        if (feed.Count != 0) {
            for (int i = 0; i < feed.Count; i++) {
                if (feed[i] != null) {
                    feed[i].transform.position = Vector3.Lerp(feed[i].transform.position, transform.position, pickups_lerp_speed * Time.deltaTime);
                    var distance = Vector3.Distance(transform.position, feed[i].transform.position); //위치 구하기.
                    if (distance < 0.1) {
                        feed[i].SetActive(false);
                        float size = (float)(transform.localScale.x + 0.01);
                        transform.localScale = new Vector3(size, size, size);
                        GameObject tmp = feed[i];
                        feed.Remove(feed[i]);
                        Destroy(tmp);
                    }
                } else {
                    Debug.Log("count : " + feed.Count);
                    Debug.Log("i : " + i);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup1")) {
            other.transform.parent = transform;
            feed.Add(other.gameObject);
        }
    }
}
