using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    [SyncVar]
    BallState ballState;
    public GameObject ball;

	// Use this for initialization
	void Start () {
        InitState();
		
	}

    [Server]
    void InitState()
    {
        ballState = new BallState { x = 0, y = 0, z = 0 };
    }
	
	// Update is called once per frame
	void Update () {
        SyncMovement();
		
	}

    public void SyncMovement()
    {
        Debug.Log("Ballstate.z = " + ballState.z);
        ball.transform.position = new Vector3(ballState.x, ballState.y, ballState.z);
    }


    public void MovedBall(Vector3 v)
    {
        ballState = new BallState { x = ballState.x + v.x, y = ballState.y + v.y, z = ballState.z + v.z };
    }
}
