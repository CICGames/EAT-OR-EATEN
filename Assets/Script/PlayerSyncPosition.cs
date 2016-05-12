﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncPosition : NetworkBehaviour {

    [SyncVar]
    private Vector3 syncPos;

    [SerializeField]
    Transform myTransform;

    [SerializeField]
    float lerpRate = 15;

    void FixedUpdate() {
        TransmitPosition();
        LerpPosition();
    }

    void LerpPosition() {
        if (!isLocalPlayer) {
            myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
        }
    }

    [Command]
    void CmdProvidePostionToServer(Vector3 pos) {
        syncPos = pos;
    }

    [ClientCallback]
    void TransmitPosition() {
        if (isLocalPlayer) {
            CmdProvidePostionToServer(myTransform.position);
        }
    }

}
