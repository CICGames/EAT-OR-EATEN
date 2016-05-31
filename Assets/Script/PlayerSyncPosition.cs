using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class PlayerSyncPosition : NetworkBehaviour {

    [SyncVar]
    private Vector3 syncVelocity;
    [SyncVar]
    private Vector3 syncPosition;

    [SerializeField]
    Rigidbody myRigidbody;
    //Transform myTransfrom;

    //[SyncVar]
    //private Vector3 syncPos;

    //[SerializeField]
    //Transform myTransform;

    [SerializeField]
    float lerpRate = 15;

    void FixedUpdate() {
        TransMoveInformation();
        LerpMove();
        //TransmitPosition();
        //LerpPosition();
    }

    private void LerpMove() {
        if (!isLocalPlayer) {
            myRigidbody.position = Vector3.Lerp(myRigidbody.position, syncPosition, Time.deltaTime * lerpRate);
            myRigidbody.AddForce(syncVelocity);
            syncVelocity = Vector3.zero;
        }

        //Debug.Log("Sync: " + syncPosition + ", " + syncVelocity);
    }

    [Command]
    void CmdProvidePostionToServer(Vector3 pos, Vector3 veo) {
        syncPosition = pos;
        syncVelocity = veo;

    }

    [ClientCallback]
    private void TransMoveInformation() {
        if (isLocalPlayer) {
            CmdProvidePostionToServer(myRigidbody.position, myRigidbody.velocity);
        }
    }

    //void LerpPosition() {
    //    if (!isLocalPlayer) {
    //        myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
    //    }
    //}

    //[Command]
    //void CmdProvidePostionToServer(Vector3 pos) {
    //    syncPos = pos;
    //}

    //[ClientCallback]
    //void TransmitPosition() {
    //    if (isLocalPlayer) {
    //        CmdProvidePostionToServer(myTransform.position);
    //    }
    //}
}
