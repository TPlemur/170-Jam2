using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private bool isOpen = false;

    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(!isOpen)
        {
            isOpen = true;
            animator.SetTrigger("open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isOpen)
        {
            isOpen = false;
            animator.SetTrigger("close");
        }
    }
}
