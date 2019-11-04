using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSpeed = 3;
    float x, y;
    float velX, velY;
    public float maxVel;
    Rigidbody rigid;
    public GameObject firePos;
    public GameObject bullet;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void FixedUpdate()
    {
        x = Input.GetAxis("Mouse X") * mouseSpeed;
        y = Input.GetAxis("Mouse Y") * mouseSpeed;
        transform.Rotate(0,x,0);
        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");
        Vector3 forwardVel = transform.forward * maxVel * -velY;
        Vector3 horizontalVel = transform.right * maxVel * velX;
        Vector3 sumVector = forwardVel + horizontalVel;
        sumVector.y = rigid.velocity.y;
        rigid.velocity = sumVector;
        Debug.DrawRay(transform.position, transform.forward);


    }
    void Fire()
    {
        // empty quaternion such that it doesnt affect rotation
        GameObject b = Instantiate(bullet, firePos.transform.position, new Quaternion());
    }
}
