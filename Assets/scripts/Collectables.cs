using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectables : MonoBehaviour
{
    public UnityEvent onTrigger;
    public Canvas text;

    bool canInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = true;
            text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = false;
            text.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (canInteract && Input.GetKeyDown("e"))
        {
            onTrigger.Invoke();
        }
    }
}
