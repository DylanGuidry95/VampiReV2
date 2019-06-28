using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwapBehaviour : MonoBehaviour {

    public Transform Model;
    public Transform Ragdoll;
    public Transform RagdollHanger;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void ActivateModel()
    {
        Model.gameObject.SetActive(true);
        Ragdoll.gameObject.SetActive(false);
    }

    public void ActivateRagdoll()
    {
        Ragdoll.gameObject.SetActive(true);
        Model.gameObject.SetActive(false);
    }
}
