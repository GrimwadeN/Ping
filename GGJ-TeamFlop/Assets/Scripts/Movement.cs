using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    [HideInInspector]
    public Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


        // Keyboard movement
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += -transform.right * speed * Time.deltaTime;
        }

        // Rotate player when mouse button is held down
        if(Input.GetMouseButton(1))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, Input.GetAxis("Mouse X") * rotationSpeed);         
        }


    }
}
