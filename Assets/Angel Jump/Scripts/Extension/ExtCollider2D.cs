using UnityEngine;
using System.Collections;

public static class ExtCollider2D {

	public static float PosX(this Collider2D collider) {
		return collider.transform.position.x;
	}
}
