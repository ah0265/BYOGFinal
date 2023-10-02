using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPlace : MonoBehaviour
{
    public delegate void TogglePlayerBool(GameObject player);
    public static event TogglePlayerBool togglePlayerBool;
    private void OnTriggerEnter(Collider other)
    {
        togglePlayerBool(other.gameObject);

    }
    private void OnTriggerExit(Collider other)
    {
        togglePlayerBool(other.gameObject);
    }
}
