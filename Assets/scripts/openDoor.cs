using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;

    private bool isOpen = false;

    private Vector3 doorLeftStart;
    private Vector3 doorRightStart;

    private Vector3 doorLeftEnd;
    private Vector3 doorRightEnd;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        doorLeftStart = doorLeft.transform.position;
        doorRightStart = doorRight.transform.position;

        doorLeftEnd = doorLeftStart;
        doorLeftEnd.x += -4;

        doorRightEnd = doorRightStart;
        doorRightEnd.x += 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isOpen)
        {
            isOpen = false;
            animator.SetTrigger("close");
            //doorLeft.transform.position = doorLeftStart;
            //doorRight.transform.position = doorRightStart;
        }
        else
        {
            isOpen = true;
            animator.SetTrigger("open");
            //doorLeft.transform.position = doorLeftEnd;
            //doorRight.transform.position = doorRightEnd;
        }
    }
}
