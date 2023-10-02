using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class TwoDialougeUI : MonoBehaviour
{
    public TMP_Text textLabel;
    [SerializeField] private GameObject dialougeBox;
    //[SerializeField] private DialougeObject TestDialouge;

    private ResponseHandler _responseHandler;
    private Typewriter _typewriter;

    public static TwoDialougeUI TwoInstance { get; private set; }

    private void Awake()
    {
        TwoInstance = this; 
    }
    private void Start()
    {
        _typewriter = GetComponent<Typewriter>();
        //CloseDialougeBox();
        //ShowDialouge(TestDialouge);
    }


    public void ShowDialouge(DialougeObject dialougeObject)
    {
        dialougeBox.SetActive(true);
        StartCoroutine(StepThroughDialouge(dialougeObject));

    }
    
    

    private IEnumerator StepThroughDialouge(DialougeObject dialougeObject)
    {

        for (int i = 0; i < dialougeObject.Dialouge.Length; i++)
        {
            string dialouge = dialougeObject.Dialouge[i];
            yield return _typewriter.Run(dialouge, textLabel);

            if (i == dialougeObject.Dialouge.Length - 1 && dialougeObject.HasResponses)
                break;
            
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
        }

        if (dialougeObject.HasResponses)
        {
            _responseHandler.ShowResponses(dialougeObject.Responses);
        }

        else
        {
            CloseDialougeBox();
        }
    }

    private void CloseDialougeBox()
    {
        dialougeBox.SetActive(false);
        textLabel.text = string.Empty;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Area3");
    }
}