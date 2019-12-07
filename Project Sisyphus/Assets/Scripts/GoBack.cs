using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Handles the "Go Back" functionality on menus and levels
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("main", LoadSceneMode.Single);
        }
    }
}
