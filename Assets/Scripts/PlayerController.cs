using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public Rigidbody rig;

    private bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;
        
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        Vector3 vel = rig.velocity;
        vel.y = 0;

        if(vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }
}
