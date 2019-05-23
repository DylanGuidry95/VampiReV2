using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Dylan;
using UnityEngine;

public class InteractionColliderBehaviour : MonoBehaviour
{

    public GrabbableBehaviour HighLightedObject;
    public Vector3 HitLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        HitLocation = other.transform.position;
        HighLightedObject = other.GetComponent<GrabbableBehaviour>();
        HighLightedObject?.HighLight(true);
    }

    private void OnTriggerExit(Collider other)
    {
        HighLightedObject?.HighLight(false);
        HighLightedObject = null;
    }
}
