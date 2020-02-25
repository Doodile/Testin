using UnityEngine;
using System.Collections;

public class FirstPersonMove : MonoBehaviour {


	// Rotation variables
	private float   rotY,
					rotX,
					sensitivity = 10.0f;

    // Speed variables
    private float speed = 2f,
                     speedHalved = 2f,
                     speedOrigin = 2f;




    void Start()
	{

	}
	
	// FixedUpdate is used for physics based movement
	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis("Horizontal"); // set a float to control horizontal input
		float vertical = Input.GetAxis("Vertical"); // set a float to control vertical input
        MouseLook(); // Call the player look function which controls the mouse
		PlayerMove(horizontal,vertical); // Call the move player function sending horizontal and vertical movements

	}
	
	private void MouseLook()
	{
		rotX += Input.GetAxis("Mouse X")*sensitivity; // set a float to control Mouse X input
		rotY += Input.GetAxis("Mouse Y")*sensitivity; // set a float to control Mouse Y input
		rotY = Mathf.Clamp (rotY, -90f, 90); // Lock rotY to a 90 degree angle for looking up and down
		transform.localEulerAngles = new Vector3(0,rotX,0); // Rotate the player mode left and right
		transform.GetChild(0).transform.localEulerAngles = new Vector3(-rotY,0,0); // Rotate the camera up and down rather than the player model
	}
	
	private void PlayerMove(float h, float v)
	{
		if (h != 0f || v != 0f) // If horizontal or vertical are pressed then continue
		{
			if(h != 0f && v != 0f) // If horizontal AND vertical are pressed then continue
			{
				speed = speedHalved; // Modify the speed to adjust for moving on an angle
			}
			else // If only horizontal OR vertical are pressed individually then continue
			{
				speed = speedOrigin; // Keep speed to it's original value
            }
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (transform.right * h) * speed * Time.deltaTime); // Move player based on the horizontal input
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (transform.forward * v) * speed * Time.deltaTime); // Move player based on the vertical input
			
		}
		else 	// If horizontal or vertical are not pressed then continue
		{
			
		}
	}
	
	
}