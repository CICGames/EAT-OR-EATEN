using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float defaultForwardDistance;
    public float defaultHeightDistance;

    private Transform localPlayer = null;
    private Vector3 defaultPlayerScale;

    private const float DISTANCE_RATE = 4.3f;

    void Update() {
        if (localPlayer != null){
            FollowPlayer();
        }
    }

    public void SetPlayer(Transform player) {
        localPlayer = player;
        defaultPlayerScale = localPlayer.localScale;
    }


    private void FollowPlayer() {
        Vector3 localPlayerPosition = localPlayer.position;
        float increaseRate = (localPlayer.localScale.x - defaultPlayerScale.x) * DISTANCE_RATE;
        float forwardDistance = defaultForwardDistance + increaseRate;
        float heightDistance = defaultHeightDistance + increaseRate;
        
        transform.position = new Vector3(localPlayerPosition.x, localPlayerPosition.y + heightDistance, localPlayerPosition.z - forwardDistance);
        transform.LookAt(localPlayer);
    }
    
}
