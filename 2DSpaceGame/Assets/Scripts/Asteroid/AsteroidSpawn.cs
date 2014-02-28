using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {
	/* Spawns asteroids at a spawn point
	 * It will spawn asteroids at random y coordinates relative to the spawn point, but will stay within the y coordinate 
	 * the camera.
	 */

	public float spawnInterval; //The time between spawning asteroids
	private Camera camera; //Get the main camera
	private float maxDistance; //The max distance to spawn away from camera on the Y coordinate
	private float tick; //A tick occurs when tick >= spawnInterval. Spawn asteroid every time there's a tick.
	// Use this for initialization
	void Start () {
		camera = Camera.main;
		maxDistance = camera.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		tick += Time.deltaTime;
		if(tick>= spawnInterval){
			tick=0f;
			spawnAsteroid(Random.Range(-maxDistance,maxDistance)+camera.transform.position.y);
		}

	}

	/* Spawns an asteroid at location given a y coordinate*/
	private void spawnAsteroid(float y){
		GameObject newAsteroid = Instantiate(Resources.Load ("Prefabs/GameObjects/Asteroids/Asteroid"),new Vector3(transform.position.x,y,0),transform.rotation) as GameObject;
		newAsteroid.rigidbody2D.AddForce(-Vector2.right* Random.Range (1,1000)+GameObject.FindGameObjectWithTag("Player").rigidbody2D.velocity);
		newAsteroid.rigidbody2D.AddTorque(Random.Range(1,100));
	
	}
}
