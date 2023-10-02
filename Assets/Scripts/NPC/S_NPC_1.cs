using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_NPC_1 : MonoBehaviour
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
            DialougeUI.Instance.textLabel.text = string.Empty;
            DialougeUI.Instance.ShowDialouge(TestDialouge1);

        }

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
