using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Portal[] MasterPortals;
    public Portal[] SlavePortals;

    Portal currentPortal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < SlavePortals.Length; i++)
        {
            if (SlavePortals[i].canSee)
            {
                currentPortal = SlavePortals[i];
                MasterPortals[i].transform.position = new Vector3(MasterPortals[i].transform.position.x, 0.91f, MasterPortals[i].transform.position.z);
            }
        }
        for (int i = 0; i < SlavePortals.Length; i++)
        {
            if( SlavePortals[i] != currentPortal)
            {
                MasterPortals[i].transform.position = new Vector3(MasterPortals[i].transform.position.x, 20f, MasterPortals[i].transform.position.z);

            }
        }
    }
}
