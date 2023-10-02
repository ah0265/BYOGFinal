using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void Game()
    {
        SceneManager.LoadScene("Area1");
    }
}
