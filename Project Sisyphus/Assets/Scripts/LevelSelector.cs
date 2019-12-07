using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public int currentSelection = 0;
    public int currentDifficulty =0;
    public string[] level = {"11", "12", "13", "21", "22", "23" };
    public GameObject selector;
    private GameObject indicator;
    private RawImage selectionImage;
    private int offset;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //Handle inputs
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentDifficulty = Mathf.Abs(currentDifficulty + 1) % 2;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentDifficulty = Mathf.Abs(currentDifficulty - 1) % 2;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentSelection = Mathf.Abs(currentSelection + 1) % 3;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentSelection = Mathf.Abs(currentSelection - 1) % 3;
        }

        //Updates color as indicator moves
        for (int i = 0; i < level.Length; i++)
        {
            indicator = GameObject.Find(level[i]);
            selectionImage = indicator.GetComponent<RawImage>();
            selectionImage.color = new Color(0, 42, 214);
        }

        //Offsets level selection according to difficulty.
        if (currentDifficulty == 1) {
            offset = 3;
        }
        else
        {
            offset = 0;
        }

        indicator = GameObject.Find(level[ currentSelection+offset]);
        selectionImage = indicator.GetComponent<RawImage>();
        selectionImage.color = new Color(214, 42, 0);

        //Starts selected level
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(level[currentSelection+offset], LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("test", LoadSceneMode.Single);
        }
    }
}
