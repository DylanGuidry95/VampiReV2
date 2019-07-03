using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTestRotation : MonoBehaviour
{
    public GameObject bone;

    public GameObject target;

    private float speed = 1;

	void Start () {
		
	}

    private Vector3 currentAvgPos;

    void LateUpdate()
    {
        //var averagePos = target.transform.position;
        //Vector3 rotate = currentAvgPos - averagePos;
        //currentAvgPos = averagePos;
        //bone.transform.Rotate(new Vector3(0, 0, 1), -rotate.z * 20);
        //bone.transform.LookAt(-target.transform.position, Vector3.down);
        bone.transform.Rotate(new Vector3(0, 0, 1), -1.0f);

    }
    
}
