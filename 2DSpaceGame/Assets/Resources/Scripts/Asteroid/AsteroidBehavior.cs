using UnityEngine;
using System.Collections;

/* Asteroids will be destroyed after a specified lifetime.
 * This is to reduce lag and to prevent huge number of instances of asteroids during runtime.
 */
public class AsteroidBehavior : MonoBehaviour {
	public float lifetime = 20f; //How long the asteroid will last.
	private float currentTime;
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if(currentTime>lifetime){
			destroy();
		}
	}

	public void destroy(){
		Destroy (this.gameObject);
	}
}
