using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private Vector3 movement;
    private Vector3 velocity;
    private bool isGrounded;
    private CharacterController controller;

    public float normalSpeed = 17f;
    public float sprintSpeed = 30f;
    public float speed;
    [SerializeField] private float jumpHeight = 3.5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private LayerMask obstacleMask;

    private GameObject playerCamera;

    void Start()
    {
        speed = normalSpeed;
        controller = this.GetComponent<CharacterController>();
        playerCamera = GameObject.Find("PlayerCamera");
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, obstacleMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        var inputHorizontal = Input.GetAxis("Horizontal");
        var inputVertical = Input.GetAxis("Vertical");

        Move(inputHorizontal, inputVertical);
    }

    private void Move(float inputX, float inputZ)
    {
        movement = transform.right * inputX + transform.forward * inputZ;
        controller.Move(movement * speed * Time.deltaTime);
        velocity.y = 0f;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
