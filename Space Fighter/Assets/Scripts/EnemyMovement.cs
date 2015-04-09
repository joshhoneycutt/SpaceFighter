using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed=1.0f;
	public float x = 0;
	private Vector3 startPosition;
	private Quaternion startRotation;
	private float startHealth;
	public float health = 50f;
	public GameObject EnemyBullet;
	public Transform EnemySpawn;
	public float fireRate;
	public int scoreValue;
	private Player_Movement player_Movement;
	
	private float nextFire;

	// Use this for initialization
	void Start () {
		// starting positions
		startHealth = health;
		startPosition = transform.position;
		startRotation = transform.rotation;

		// calls the Player_Movement script for score upodating
		GameObject gameControllerObject = GameObject.FindWithTag ("Player_Movement");
		if (gameControllerObject != null)
		{
			player_Movement = gameControllerObject.GetComponent <Player_Movement>();
		}
		if (player_Movement == null)
		{
			Debug.Log ("Cannot find 'Player_Movement' script");
		}
	}
	
	void Update () {

		// enemy bullets
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(EnemyBullet, EnemySpawn.position, EnemySpawn.rotation);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += Vector3.down * speed * Time.deltaTime; // move down

		if (x == 1) {
			transform.Translate (Vector3.right * Time.deltaTime, Camera.main.transform); // move right
		}
		else if (x == 2) {
			transform.Translate (Vector3.left * Time.deltaTime, Camera.main.transform); // move left
		}
		else if (x == 0) {
			return; // do nothing 
		}
	}

	// handles collisions
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet")
		{
			Damage(60);
			player_Movement.AddScore (scoreValue);
		}
		else if (coll.gameObject.tag == "Enemy") 
		{
			return;
		} 
		else
		{
			Damage(60);
		}
	}

	// calculates damage
	public void Damage(float amount) 
	{
		health -= amount;
		if (health < 0f) {
			KillAndReset ();
		}
	}

	// resets Enemy Ship
	public void KillAndReset() 
	{
		x = Random.RandomRange (-1, 3);
		health = startHealth;
		transform.position = startPosition;
		transform.rotation = startRotation;
	}

	// picks a random direction each time it resets
	void Awake() {
		x = Random.RandomRange (-1, 3);
	}
}