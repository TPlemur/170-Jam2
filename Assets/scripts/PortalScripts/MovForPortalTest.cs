using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovForPortalTest : PortalTraveller
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float mouseSense = 300;
    public float globalGravity = 50;
    public float playerGravity = 50;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Camera mainCam;

    Rigidbody rb;

    public int flipTicks;
    public UnityEvent fog;
    int curTicks;
    Transform tf;

    private void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Physics.gravity = new Vector3(0, -globalGravity, 0);
        tf = GetComponent<Transform>();
        curTicks = flipTicks;

        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MyInput();
        //SpeedControl();

        // handle drag
        rb.drag = groundDrag;

        if (curTicks < flipTicks)
        {
            tf.Rotate(new Vector3(0, 0, 180 / flipTicks));
            curTicks++;
        }
        else
        {
            //rotate player camera
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime, 0));
            mainCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -mouseSense * Time.deltaTime, 0, 0));
        }
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
        rb.AddForce(Physics.gravity.normalized*playerGravity);
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

    //gravity functions
    public void fancyFlip()
    {
        //protect against being called before function ends
        if (curTicks == flipTicks)
        {
            Physics.gravity = Physics.gravity * -1;
            curTicks = 0;
            fog.Invoke();
        }
    }
    public void fastFlip()
    {
        Physics.gravity = Physics.gravity * -1;
        fog.Invoke();
    }
}
