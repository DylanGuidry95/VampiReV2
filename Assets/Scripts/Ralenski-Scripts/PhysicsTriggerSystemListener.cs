using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;

public class PhysicsTriggerSystemListener : MonoBehaviour
{
    public GameEventListener PhysicsListener;

    public GameEvent gameEvent;
    public List<GameEventListener> Listeners = new List<GameEventListener>();

    void RaiseEvent(List<GameEventListener> GEL)
    {
        GEL[].Event = gameEvent;
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
