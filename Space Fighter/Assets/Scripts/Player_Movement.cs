using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public float speed=1.0f;
	public string axisName = "Horizontal";
	public GameObject Bullet;
	public Transform ShotSpawn;
	public float fireRate;
	public GUIText scoreText;
	public int score;
	public GUIText WinGame;
	public GUIText LoseGame;
	public AudioClip LasorSound;

	private float nextFire;

	
	// Use this for initialization
	void Start () {
		score = 0;
	}

	void Update ()
	{
		if (Input.GetKeyDown("space") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(Bullet, ShotSpawn.position, ShotSpawn.rotation);
			audio.PlayOneShot(LasorSound);
		}
	}

	// Update is called once per frame
	//movement from player input
	void FixedUpdate () {
		if (Input.GetAxis (axisName) < 0)
		{
			Vector3 newScale = transform.localScale;
			newScale.y = 1.0f;
			newScale.x = 1.0f;
			transform.localScale = newScale;
		}
		else if (Input.GetAxis (axisName) > 0)
		{
			Vector3 newScale =transform.localScale;
			newScale.x = 1.0f;
			transform.localScale = newScale;
		}
		transform.position += transform.right *Input.GetAxis(axisName)* speed * Time.deltaTime;
	}

	// handles points for collisions
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") 
		{
			AddScore (-20);
		}
		else
		{
			AddScore (-5);
		}
	}

	// updates score value
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	// updates score in game and displays win/lose
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
		if (score == 500) {
			WinGame.text = "You Win"; // displays when score reaches 500
		} 
		if (score == -200) {
			LoseGame.text = "Sorry you Lose"; // displays when score reaches -200
		}
	}
}
