using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerLVL1 : MonoBehaviour
{
    [SerializeField] private DialougeObject TestDialouge;
    // Start is called before the first frame update
    void Start()
    {
        DupDialougeUI.DupInstance.ShowDialouge(TestDialouge);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
