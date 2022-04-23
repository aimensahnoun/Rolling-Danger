using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float horzInput, vertInput;
    private Rigidbody playerBody;

    [SerializeField] private float speed = 10;

    [SerializeField] private float jumpForce = 10;
    private bool isPlayerJumping = false;
    private bool isPlayerGrounded;


    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        horzInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPlayerJumping = true;
        }

    }


    private void FixedUpdate()
    {

        Vector3 movementVector = new Vector3(horzInput, 0, vertInput);

        movementVector *= speed;

        playerBody.AddForce(movementVector , ForceMode.Acceleration);


        Ray ray = new Ray(transform.position , Vector3.down);


        if(Physics.Raycast(ray , transform.localScale.x / 2f + 0.01f))
        {
            isPlayerGrounded = true;
        }
        else
        {
            isPlayerGrounded = false;
        }


        if (isPlayerJumping && isPlayerGrounded)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isPlayerJumping = false;
        }


    }

}
