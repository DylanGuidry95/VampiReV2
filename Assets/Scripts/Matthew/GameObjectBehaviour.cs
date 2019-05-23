using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectBehaviour : MonoBehaviour {
    public UnityEngine.Events.UnityEvent StartResponse;
	// Use this for initialization
	void Start ()
    {
        StartResponse.Invoke();	
	}
	
 
}
