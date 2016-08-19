using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    Character _owner;

    public void SetOwner(Character _owner) {
        this._owner = _owner;
    }

	void OnCollisionEnter(Collision collision) {
        GameObject hit = collision.gameObject;
        Character character = hit.GetComponent<Character>();

        if (!_owner.Equals(character)) {
            if (character != null) {
                character.TakeDamage(10);
            }

            Destroy(gameObject);
        }
    }
}
