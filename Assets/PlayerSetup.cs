using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    public Behaviour[] componentsToDisable;
	// Use this for initialization
	void Start () {
        if(!isLocalPlayer)
        {
            foreach(Behaviour b in componentsToDisable)
            {
                b.enabled = false;
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
