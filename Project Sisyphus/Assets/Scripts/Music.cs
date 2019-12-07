using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class is mostly to maintain music playback.
public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
