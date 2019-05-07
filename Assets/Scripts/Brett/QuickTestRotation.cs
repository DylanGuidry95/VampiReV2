using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTestRotation : MonoBehaviour
{
    public GameObject bone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bone.transform.Rotate(new Vector3(0, 0, 1), -1.0f);
	}
}
