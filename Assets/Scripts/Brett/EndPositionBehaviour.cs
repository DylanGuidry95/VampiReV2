using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;

public class EndPositionBehaviour : MonoBehaviour
{
    public GameEvent gameEvent;
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameEvent.Raise();
        }
    }
}
