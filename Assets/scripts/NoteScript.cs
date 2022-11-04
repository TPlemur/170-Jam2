using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteScript : MonoBehaviour
{
    public Image noteImage;
    // Start is called before the first frame update
    void Start()
    {
        noteImage.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ShowNoteImage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            HideNoteImage();
        }
    }

    // Update is called once per frame
    public void ShowNoteImage()
    {
        noteImage.enabled = true;
        //should disable movement of player
    }
    public void HideNoteImage()
    {
        noteImage.enabled = false;
        //reenable movement
    }
}
