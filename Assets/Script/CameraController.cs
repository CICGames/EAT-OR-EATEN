using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float forwardDistance;
    public float heightDistance;

    private Transform localPlayer = null;

    void Update() {
        if (localPlayer != null){
            FollowPlayer();
        }
    }

    public void SetPlayer(Transform player) {
        localPlayer = player;
    }


    private void FollowPlayer() {
        Vector3 localPlayerPosition = localPlayer.position;

        transform.position = new Vector3(localPlayerPosition.x, localPlayerPosition.y + heightDistance, localPlayerPosition.z - forwardDistance);
        transform.LookAt(localPlayer);
    }
    
}
