using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Assets.Scripts.Brett.NpcBehaviour))]
public class DetectionScirtVisual : MonoBehaviour {
	public Assets.Scripts.Brett.NpcBehaviour BehaviourRef;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		BehaviourRef = GetComponent<Assets.Scripts.Brett.NpcBehaviour>();	
	}

	void GenerateRuntimeSkirt()
	{
		
	}

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		if(BehaviourRef == null)
			BehaviourRef = GetComponent<Assets.Scripts.Brett.NpcBehaviour>();
		var angle = BehaviourRef.AngleOfView;
		var Distance = BehaviourRef.DistanceOfView;

		Gizmos.color = Color.yellow;
        List<Ray> rays = new List<Ray>();
        for (float i = -angle; i < angle; i += 1f)
        {
            Quaternion spread = Quaternion.AngleAxis(i, transform.up);
            Vector3 newVec = spread * transform.forward;
            rays.Add(new Ray(transform.position, newVec));
        }
        foreach (var r in rays)
        {
			RaycastHit hit;
			if(Physics.Raycast(r.origin, r.direction, out hit, Distance))			
				Gizmos.DrawLine(r.origin, hit.point);			
			else
	            Gizmos.DrawRay(r.origin, r.direction * Distance);
        }

		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, transform.forward * Distance);  
	}
}
