using UnityEngine;
using System.Collections;

public class Bullet_Move : MonoBehaviour
{
	public float speed;
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
		transform.position += Vector3.up * speed * Time.deltaTime;
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		DestroyObject (gameObject);
	}
}