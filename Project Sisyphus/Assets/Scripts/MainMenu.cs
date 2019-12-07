using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Handles input for main menu
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("level", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("controls", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("story", LoadSceneMode.Single);
        }
    }
}
