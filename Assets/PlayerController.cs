using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public struct BallState
{
    public float x;
    public float y;
    public float z;
}

public class PlayerController : NetworkBehaviour {

    // Use this for initialization
    Rigidbody rb;
    public GameObject nonPlayer;
    Rigidbody rb2;
    public GameObject directionReference;
    private float shotStrength = 4f;
    public GameController gc;
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        nonPlayer = GameObject.FindGameObjectWithTag("np");
        rb = gameObject.GetComponent<Rigidbody>();
        rb2 = nonPlayer.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("a"))
        {
            rb.AddForce(-directionReference.transform.right * shotStrength, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("d"))
        {
            rb.AddForce(directionReference.transform.right * shotStrength, ForceMode.Impulse);
        }

        if(Input.GetKeyDown("space"))
        {
            Debug.Log("Im about to tell the server to move the ball!");
            CmdMoveBall();
        }
    }

    [Command]
    public void CmdMoveBall()
    {
        Vector3 v = new Vector3(0, 0, -.1f);
        gc.MovedBall(v);
        Debug.Log("Server was told to move ball");
    }
}
