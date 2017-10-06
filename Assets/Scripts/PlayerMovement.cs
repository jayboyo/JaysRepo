using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {


    public float speed = 10.0f;
    public Rigidbody rb;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 10.0f;


    Component[] renderer;
    Vector3 movement;

    





    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {      

	}

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        //CapsuleCollider CapsuleRef;

        //GetComponentsInChildren(typeof(MeshRenderer));

        //CapsuleRef.GetComponent<MeshRenderer>().material.color = Color.blue;


        renderer = gameObject.GetComponentsInChildren<Renderer>();
   
        if (renderer[0] is Renderer)
        {
            Renderer temp = (Renderer)renderer[0];
            temp.material.color = Color.blue;
        }

    }


    // Update is called once per frame
    void Update () {

        if (!isLocalPlayer)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
        
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
            
    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        NetworkServer.Spawn(bullet);


        Destroy(bullet, 2.0f);

    }


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float mh = Input.GetAxis("Mouse Y");
        float mv = Input.GetAxis("Mouse X");

        //Move(h, v);
        //Rotate(mh, mv);

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
