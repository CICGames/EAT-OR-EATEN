using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class PlayerSyncPosition : NetworkBehaviour {

    [SyncVar] private Vector3 syncPosition = Vector3.zero;
    [SyncVar] private Quaternion syncRatation = Quaternion.identity;
    [SyncVar] private Vector3 syncScale = Vector3.zero;
    
    [SerializeField] Transform myTransfrom;
  
    [SerializeField] float lerpRate = 15;

    void FixedUpdate() {
        TransMoveInformation();
        LerpMove();
    }

    private void LerpMove() {
        if (!isLocalPlayer) { // 플레이어 자신이 아닌 다른 플레이어들 움직임
            myTransfrom.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime * lerpRate);
            myTransfrom.rotation = Quaternion.Lerp(transform.rotation, syncRatation, Time.deltaTime * lerpRate);
            myTransfrom.localScale = Vector3.Lerp(transform.localScale, syncScale, Time.deltaTime * lerpRate);
        }
    }

    [Command] // 클라이언트에서 서버로 전송? 적용?
    void CmdProvidePostionToServer(Vector3 pos, Quaternion rot, Vector3 scale) {
        syncPosition = pos;
        syncRatation = rot;
        syncScale = scale;
    }

    [ClientCallback] // 클라이언트에서만 동장
    private void TransMoveInformation() {
        if (isLocalPlayer) {
            CmdProvidePostionToServer(myTransfrom.position, myTransfrom.rotation, myTransfrom.localScale);
        }
    }
}
