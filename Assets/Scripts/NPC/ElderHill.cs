using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderHill : MonoBehaviour
{
    [SerializeField] private DialougeObject TestDialouge1;
    public bool talk;
    private void OnTriggerEnter(Collider other)
    {
        talk = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (talk == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                talk= true;
                TwoDialougeUI.TwoInstance.textLabel.text = string.Empty;
                TwoDialougeUI.TwoInstance.ShowDialouge(TestDialouge1);
                

            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
