using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class PlayerSyncPosition : NetworkBehaviour {

    [SyncVar] private Vector3 _syncPosition = Vector3.zero;
    [SyncVar] private Quaternion _syncRatation = Quaternion.identity;
    [SyncVar] private Vector3 _syncScale = Vector3.zero;
    
    [SerializeField] Transform _myTransfrom;
  
    [SerializeField] float _lerpRate = 15;

    void FixedUpdate() {
        TransMoveInformation();
        LerpMove();
    }

    private void LerpMove() {
        if (!isLocalPlayer) { // 플레이어 자신이 아닌 다른 플레이어들 움직임
            _myTransfrom.position = Vector3.Lerp(transform.position, _syncPosition, Time.deltaTime * _lerpRate);
            _myTransfrom.rotation = Quaternion.Lerp(transform.rotation, _syncRatation, Time.deltaTime * _lerpRate);
            _myTransfrom.localScale = Vector3.Lerp(transform.localScale, _syncScale, Time.deltaTime * _lerpRate);
        }
    }

    [Command] // 서버에서 수행
    void CmdProvidePostionToServer(Vector3 _pos, Quaternion _rot, Vector3 _scale) {
        _syncPosition = _pos;
        _syncRatation = _rot;
        _syncScale = _scale;
    }

    [ClientCallback] // 클라이언트에서만 동장
    private void TransMoveInformation() {
        if (isLocalPlayer) {
            CmdProvidePostionToServer(_myTransfrom.position, _myTransfrom.rotation, _myTransfrom.localScale);
        }
    }
}
