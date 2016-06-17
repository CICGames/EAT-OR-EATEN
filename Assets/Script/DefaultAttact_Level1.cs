using UnityEngine;
using System.Collections;

public class DefaultAttact_Level1 : MonoBehaviour {

    public float moveSpeed = 5f;
    private Vector3 attackPoint;

    private float testTime = 0;

    public void SetAttackPoint(Vector3 player, Vector3 point) {
        point.y = player.y;
        transform.position = Vector3.Lerp(player, point, 0.4f);
        transform.LookAt(point);
        attackPoint = point;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, attackPoint, Time.deltaTime * moveSpeed);

        ParticleSystem particle = GetComponent<ParticleSystem>();
        if (!particle.isPlaying)
            Destroy(transform.gameObject);
    }
}
