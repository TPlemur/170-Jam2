using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EscapePodCheck : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject Instruction2;
    public UnityEvent Win;
    public bool Action = false;

    public MovForPortalTest player;
    [SerializeField] private Text escapeText;

    void Start()
    {
        Instruction.SetActive(false);
        Instruction2.SetActive(false);
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
        Instruction2.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                if(player.datapads == 6)
                {
                    Instruction.SetActive(false);
                    Win.Invoke();
                    Action = false;
                }
                else
                {
                    Instruction.SetActive(false);
                    Instruction2.SetActive(true);
                    escapeText.text = "Missing " + (6 - player.datapads) + " datapads";
                    // Debug.Log("missing " + (6-player.datapads));
                    Action = false;
                }
            }
        }

    }
}
