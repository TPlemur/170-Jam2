using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovForPortalTest : MonoBehaviour
{
    CharacterController characterController;
    Camera currentCam;
    Vector3 velocityMov;

    public float mouseSense = 300;
    public float movSpeed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        currentCam = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //move acording to inputs
        velocityMov = currentCam.transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        velocityMov = Vector3.ClampMagnitude(velocityMov, 1);
        velocityMov.y = 0;
        characterController.SimpleMove(velocityMov * movSpeed * Time.deltaTime);
        //rotate
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime, 0));
        currentCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -mouseSense * Time.deltaTime, 0, 0));
    }
}
