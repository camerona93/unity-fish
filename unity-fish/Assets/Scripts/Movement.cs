using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float movementSpeed;
    public float jumpSpeed;
    public bool grounded;
    public float airDrag; // Divides movementSpeed by this number


    private float moveVel;
    private Rigidbody rb;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate() {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);

        if (grounded)
        {
            rb.AddForce(movement * movementSpeed);
        } else
        {
            rb.AddForce(movement * movementSpeed / airDrag);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jumpSpeed, rb.velocity.z);
        }
    }



    void OnTriggerEnter()
    {
        grounded = true;
    }
    void OnTriggerExit()
    {
        grounded = false;
    }
    
}
