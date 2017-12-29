﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed = 10;
	public float shotsPerSecond = 0.5f;

	void Update() {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire();
		}
	}

	void Fire() {
		Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
		GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
	}

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