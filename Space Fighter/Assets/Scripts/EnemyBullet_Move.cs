using UnityEngine;
using System.Collections;

public class EnemyBullet_Move : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	}
	
	void Update ()
	{
		transform.position += Vector3.down * speed * Time.deltaTime;
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		DestroyObject (gameObject);
	}
}
