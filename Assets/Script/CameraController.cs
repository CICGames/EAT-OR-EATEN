using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float _defaultForwardDistance;
    public float _defaultHeightDistance;

    private Transform _localPlayer = null;
    private Vector3 _defaultPlayerScale;

    private const float DISTANCE_RATE = 4.3f;

    void Update() {
        if (_localPlayer != null){
            FollowPlayer();
        }
    }

    public void SetPlayer(Transform player) {
        _localPlayer = player;
        _defaultPlayerScale = _localPlayer.localScale;
    }


    private void FollowPlayer() {
        Vector3 _localPlayerPosition = _localPlayer.position;
        float _increaseRate = (_localPlayer.localScale.x - _defaultPlayerScale.x) * DISTANCE_RATE;
        float _forwardDistance = _defaultForwardDistance + _increaseRate;
        float _heightDistance = _defaultHeightDistance + _increaseRate;
        
        transform.position = new Vector3(_localPlayerPosition.x, _localPlayerPosition.y + _heightDistance, _localPlayerPosition.z);
        transform.LookAt(_localPlayer);
    }
    
}
