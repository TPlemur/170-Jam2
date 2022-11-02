using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovForPortalTest : PortalTraveller
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float mouseSense = 300;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Camera mainCam;

    Rigidbody rb;

    private void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
        SpeedControl();

        // handle drag
        rb.drag = groundDrag;

        //rotate
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime, 0));
        mainCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -mouseSense * Time.deltaTime, 0, 0));
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public override void Teleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot)
    {
        base.Teleport(fromPortal, toPortal, pos, rot);
        rb.velocity = toPortal.TransformVector(fromPortal.InverseTransformVector(rb.velocity));
        rb.angularVelocity = toPortal.TransformVector(fromPortal.InverseTransformVector(rb.angularVelocity));
    }

}
