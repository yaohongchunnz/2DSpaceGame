using UnityEngine;
using System.Collections;

public class SpaceshipControls : MonoBehaviour {
	/*This script  will be attached to the spaceship.
	 * Its purpose is to control the movement of the spaceship.
	 * The spaceship can rotate, accelerate and decelerate.
	 * Rotating the space ship will make the ship rotate constantly until an opposite rotation
	 * is used.
	 */
	public float acceleration; //The forward acceleration of the spaceship.
	public float deceleration; //The backward acceleration of the spaceship.
	public float rotationSpeed; //The rotation speed of the spaceship.
	public float maxSpeed; //The Maximum acceleration speed. Current speed cannot exceed this amount.

	private float currentSpeed; //The current speed of the spaceship.
	private bool destroyed = false; //whether or not the spaceship has been destroyed.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		if(!destroyed){
			float angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;
			float direction = Input.GetAxisRaw("Vertical");
			float turn = Input.GetAxisRaw("Horizontal") * rotationSpeed;
			Vector2 thrust;
			if(direction > 0f){ //if moving forward
				thrust = new Vector2((Mathf.Cos (angle) * acceleration), (Mathf.Sin (angle) * acceleration)) ;
			}
			else{ //moving backwards
				thrust = new Vector2((Mathf.Cos (angle) * deceleration), (Mathf.Sin (angle) * deceleration)) ;
			}
			print (rigidbody2D.velocity.magnitude);
			if(direction != 0f){
				rigidbody2D.AddForce(thrust * direction * Time.deltaTime);
			}
			rigidbody2D.AddTorque(-turn * Time.deltaTime);
			
		}
	}

	private void accelerate(){
	}

	private void decelerate(){

	}
	private void rotate(){

	}
}
