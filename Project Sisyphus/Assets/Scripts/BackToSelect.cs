using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sends player back to level select
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("level", LoadSceneMode.Single);
        }
    }
}
