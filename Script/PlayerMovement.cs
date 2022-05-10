using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;
    public Transform grandChek;
    public float grandDistance = 0.4f;
    public LayerMask grandMask;
    

    Vector3 velocity = Vector3.zero;
    bool isGrounded;
    float horizontal;
    float vertical ;

    // Start is called before the first frame update
    void Start()
    {
       // controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(grandChek.position, grandDistance,grandMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y =-2f;
        }
        if(controller.isGrounded)
        {
            velocity = new Vector3(horizontal, 0.0f, vertical);
            velocity *=speed;
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            velocity.y = jumpHeight;
        }

        velocity.y += gravity *Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
