using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public bool[] rM = { false, false, false, false };
    private int count=0;

    public float TranslateSpeed;
    public float RotationSpeed;
    public float factor = .25f;
    public int max;
    public int state = 1;
    public float recWidth;
    public float angle;
    public float recHeight;
    public AudioClip stone;
    public int playerNum;
    private float heightDelta;
    private float ypos=1.9f;
    private float hit;
    private Rigidbody rb;
    private bool inputEnabled=true;
    private RaycastHit rayHit;
    public AudioSource source;

    void Start()
    {
        source=GameObject.FindObjectOfType<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    //Checks if any inputs are already being proccessed.
    bool checkIfInput(bool[] rM) {
        int sum = 0;
        for (int i = 0; i < rM.Length; i++) {
            if (rM[i] == false) {
                sum++;
            }

        }
        if (sum == rM.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Tracks the state the obelisk is in, upright, prone horz, or prone vertical
    int updateState(int currentState, int input) {
        int nextState = 0;
        factor = .25f;

        switch (currentState)
        {
            case 1:
                switch (input)
                {
                    case 0:
                        nextState = 2;
                        ypos = 1f;
                        break;

                    case 1:
                        nextState = 3;
                        ypos = 1f;
                        break;

                    case 2:
                        nextState = 2;
                        ypos = 1f;
                        break;

                    case 3:
                        nextState = 3;
                        ypos = 1f;
                        break;
                }
                break;

            case 2:
                switch (input)
                {
                    case 0:
                        nextState = 1;
                        ypos = 1.9f;
                        break;

                    case 1:
                        nextState = 2;
                        factor = .17f;
                        ypos = 1f;

                        break;

                    case 2:
                        nextState = 1;
                        ypos = 1.9f;

                        break;

                    case 3:
                        nextState = 2;
                        factor = .17f;
                        ypos = 1f;

                        break;
                }
                break;

            case 3:
                switch (input)
                {
                    case 0:
                        nextState = 3;
                        factor = .17f;
                        ypos = 1f;
                        break;

                    case 1:
                        nextState = 1;
                        ypos = 1.9f;
                        break;

                    case 2:
                        nextState = 3;
                        factor = .17f;
                        ypos = 1f;
                        break;

                    case 3:
                        nextState = 1;
                        ypos = 1.9f;
                        break;
                }
                break;
        }
        return nextState;
    }

    //CHecks for ground below the block
    void checkForFloor(int state) {
        bool cast1 = false;
        bool cast2 = false;
        Vector3 fwd = new Vector3(0, -9, 0);
        switch (state) {
            case 1:
                cast1 = Physics.Raycast(transform.position, fwd, 10);
                Debug.DrawRay(transform.position, fwd);
                cast2 = true;
                break;
            case 2:
                cast1 = Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + .5f), fwd, 10);
                cast2 = Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z - .5f), fwd, 10);
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z + .5f), fwd);
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z - .5f), fwd);
                break;
            case 3:
                cast1 = Physics.Raycast(new Vector3(transform.position.x-.5f, transform.position.y, transform.position.z), fwd, 10);
                cast2 = Physics.Raycast(new Vector3(transform.position.x+.5f, transform.position.y, transform.position.z), fwd, 10);
                Debug.DrawRay(new Vector3(transform.position.x-.5f, transform.position.y, transform.position.z), fwd);
                Debug.DrawRay(new Vector3(transform.position.x+.5f, transform.position.y, transform.position.z), fwd);
                break;
        }

        if (!(cast1&&cast2))
        {
            inputEnabled = false;
            print("Cast1 " + cast1.ToString());
            print("Cast2 " + cast2.ToString());


            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;


            if (transform.position.y < -5) {
                print("Fail");
            }
        }
    }

    //Prevents collison with other players
    bool checkForPlayer(int state, int input)
    {
        bool cast1 = false;
        bool cast2 = false;
        Vector3 fwd = new Vector3(0, 0, 0);
        int dis = 2;
        switch (input) {
            case 0:
                fwd = new Vector3(0, 0, dis);
                break;

            case 1:
                fwd = new Vector3(dis, 0, 0);
                break;

            case 2:
                fwd = new Vector3(0, 0, -dis);
                break;


            case 3:
                fwd = new Vector3(-dis, 0, 0);
                break;
        }



        switch (state)
        {
            case 1:
                cast1 = Physics.Raycast(transform.position, fwd, dis);
                Debug.DrawRay(transform.position, fwd);
                cast2 = true;
                break;
            case 2:
                cast1 = Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + .5f), fwd, dis);
                cast2 = Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z - .5f), fwd, dis);
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z + .5f), fwd);
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z - .5f), fwd);
                break;
            case 3:
                cast1 = Physics.Raycast(new Vector3(transform.position.x - .5f, transform.position.y, transform.position.z), fwd, dis);
                cast2 = Physics.Raycast(new Vector3(transform.position.x + .5f, transform.position.y, transform.position.z), fwd, dis);
                Debug.DrawRay(new Vector3(transform.position.x - .5f, transform.position.y, transform.position.z), fwd);
                Debug.DrawRay(new Vector3(transform.position.x + .5f, transform.position.y, transform.position.z), fwd);
                break;
        }

        return !(cast1 && cast2);
    }

    //Checks if player is on victory panel
    void checkVictory(int state)
    {
        Vector3 fwd = new Vector3(0, -9, 0);
        if (Physics.Raycast(transform.position, fwd, out rayHit, 9) && rayHit.transform.tag == "Finish" && state==1)
        {
            SceneManager.LoadScene("level", LoadSceneMode.Single);
        }
    }

    void FixedUpdate()
    {



        //This handles inout and sound effect processing
        if (playerNum == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && checkIfInput(rM) && inputEnabled && checkForPlayer(updateState(state,0), 0))
            {
                state = updateState(state, 0);
                
                count = 0;
                rM[0] = true;
                source.PlayOneShot(stone);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && checkIfInput(rM) && inputEnabled && checkForPlayer(updateState(state, 1), 1))
            {
                state = updateState(state, 1);
                count = 0;
                rM[1] = true;
                source.PlayOneShot(stone);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && checkIfInput(rM) && inputEnabled && checkForPlayer(updateState(state, 2), 2))
            {
                state = updateState(state, 2);
                count = 0;
                rM[2] = true;
                source.PlayOneShot(stone);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && checkIfInput(rM) && inputEnabled && checkForPlayer(updateState(state, 3), 3))
            {
                state = updateState(state, 3);
                count = 0;
                rM[3] = true;
                source.PlayOneShot(stone);
            }
        }

        if (playerNum == 2)
        {
            if (Input.GetKeyDown(KeyCode.W) && checkIfInput(rM) && inputEnabled)
            {
                state = updateState(state, 0);
                count = 0;
                rM[0] = true;
                source.PlayOneShot(stone);
            }

            if (Input.GetKeyDown(KeyCode.D) && checkIfInput(rM) && inputEnabled)
            {
                state = updateState(state, 1);
                count = 0;
                rM[1] = true;
                source.PlayOneShot(stone);
            }

            if (Input.GetKeyDown(KeyCode.S) && checkIfInput(rM) && inputEnabled)
            {
                state = updateState(state, 2);
                count = 0;
                rM[2] = true;
                source.PlayOneShot(stone);
            }

            if (Input.GetKeyDown(KeyCode.A) && checkIfInput(rM) && inputEnabled)
            {
                state = updateState(state, 3);
                count = 0;
                rM[3] = true;
                source.PlayOneShot(stone);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, ypos, transform.position.z), .02f);
        
        //Handles procedural animation
        if (rM[0])
        {
            transform.Rotate(-Vector3.left * (RotationSpeed * Time.deltaTime), Space.World);
            transform.Translate(factor * Vector3.forward * (TranslateSpeed * Time.deltaTime), Space.World);

        }

        if (rM[1])
        {
            transform.Rotate(-Vector3.forward * (RotationSpeed * Time.deltaTime), Space.World);
            transform.Translate(factor*-Vector3.left * (TranslateSpeed * Time.deltaTime), Space.World);
        }

        if (rM[2])
        {
            transform.Rotate(Vector3.left * (RotationSpeed * Time.deltaTime), Space.World);
            transform.Translate(factor * -Vector3.forward * (TranslateSpeed * Time.deltaTime), Space.World);

        }

        if (rM[3])
        {
            transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime), Space.World);
            transform.Translate(factor * Vector3.left * (TranslateSpeed * Time.deltaTime), Space.World);

        }


        //Finishes animations
        if (rM[0] && count==max) {
            rM[0] = false;
            checkVictory(state);
            count = 0;
        }
        if (rM[1] && count == max)
        {
            rM[1] = false;
            checkVictory(state);
            count = 0;
        }
        if (rM[2] && count == max)
        {
            rM[2] = false;
            checkVictory(state);
            count = 0;
        }
        if (rM[3] && count == max)
        {
            rM[3] = false;
            checkVictory(state);
            count = 0;
        }
        count++;
        checkForFloor(state);

    }
}
