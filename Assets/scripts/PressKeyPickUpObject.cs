using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyPickUpObject : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject ThisTrigger;
    public GameObject ObjectOnGround;
    public bool Action = false;

    public MovForPortalTest player;

    void Start()
    {
        Instruction.SetActive(false);
        ThisTrigger.SetActive(true);
        ObjectOnGround.SetActive(true);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
            // Debug.Log("datapads = " + player.datapads);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                player.datapads++;
                Instruction.SetActive(false);
                ObjectOnGround.SetActive(false);
                ThisTrigger.SetActive(false);
                Action = false;
            }
        }

    }
}
