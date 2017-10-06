using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed = 10.0f;
    public Rigidbody rb;

    Vector3 movement;
    Quaternion newRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {      

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float mh = Input.GetAxis("Mouse Y");
        float mv = Input.GetAxis("Mouse X");

        Move(h, v);
        Rotate(mh, mv);

    }


    void Move(float h, float v)
    {
        //movement.Set(h, 0.0f, v);
        //movement = transform.forward * h * speed * Time.deltaTime;


        movement = new Vector3(0,0,0);

        movement = (transform.forward * v * speed * Time.deltaTime) + (transform.right * h * speed * Time.deltaTime);



        rb.MovePosition(transform.position + movement);

    }

    void Rotate(float mh, float mv)
    {

        //newRotation.Set(mv, mh, 0, 0);

        //rb.MoveRotation(newRotation);

        rb.transform.Rotate(0, mv, 0);
    }

}
