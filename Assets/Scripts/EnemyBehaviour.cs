using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 150f;
	private void OnTriggerEnter2D(Collider2D col) {
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <=0) {
				Destroy(gameObject);
			}
		}
	}

}