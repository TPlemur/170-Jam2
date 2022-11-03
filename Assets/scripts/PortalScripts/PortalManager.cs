using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Portal[] telaPortals;
    public openDoor[] controlDoors;

    public float portalHeight = 0.99f;
    public float portalStorage = 20f;

    Portal currentPortal;

    public int flipTicks;
    int curTicks;
    Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        //set portal to be present at start of game
        currentPortal = telaPortals[0];
        currentPortal.transform.position = new Vector3(currentPortal.transform.position.x, portalHeight, currentPortal.transform.position.z);
        Physics.gravity = new Vector3(0, -50, 0);
        tf = GetComponent<Transform>();
        curTicks = flipTicks;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < telaPortals.Length; i++)
        {
            //switch to portal on door opening
            if (controlDoors[i].isNowOpen())
            {
                currentPortal = telaPortals[i];
                telaPortals[i].transform.position = new Vector3(telaPortals[i].transform.position.x, portalHeight, telaPortals[i].transform.position.z);
            }
            //store unused portals
            if(telaPortals[i] != currentPortal)
            {
                telaPortals[i].transform.position = new Vector3(telaPortals[i].transform.position.x, portalStorage, telaPortals[i].transform.position.z);

            }
        }
        if(curTicks < flipTicks)
        {
            tf.Rotate(new Vector3(0, 0, 180/flipTicks));
            curTicks++;
        }
    }

    public void fancyFlip()
    {
        Physics.gravity = Physics.gravity * -1;
        curTicks = 0;
    }
    public void fastFlip()
    {
        Physics.gravity = Physics.gravity * -1;
    }
}
