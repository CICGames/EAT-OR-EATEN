using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
        GameObject hit = collision.gameObject;
        Character character = hit.GetComponent<Character>();

        if (character != null) {
            character.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}
