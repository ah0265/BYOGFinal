using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritNPC : MonoBehaviour
{
    [SerializeField] private DialougeObject TestDialouge1;
    public bool talk;

    private void OnTriggerEnter(Collider other)
    {
        talk = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            talk = true;
            DupDialougeUI.DupInstance.textLabel.text = string.Empty;
            DupDialougeUI.DupInstance.ShowDialouge(TestDialouge1);

        }

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
