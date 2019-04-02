using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Dylan
{
	public class InteractionRaycastBehaviour : MonoBehaviour 
	{		
		public float MaxGrabDistance;
		public GrabbableBehaviour HighLightedObject;
		public GrabbableBehaviour GrabbedObject;		

		public Assets.Scripts.Brett.GameEvent GrabEvent;
		// Use this for initialization
		void Start () {
			MaxGrabDistance = Mathf.Clamp(MaxGrabDistance, 0.01f, Mathf.Infinity);
			LastPosition = transform.position;
		}

		public Vector3 LastPosition;
		public Vector3 Velocity;

		private void Update() 
		{

			RaycastHit hit;
			if(GrabbedObject == null)
				if(Physics.Raycast(transform.position, transform.forward, out hit, MaxGrabDistance))
				{
					if(hit.transform.GetComponent<GrabbableBehaviour>() || hit.transform.gameObject != HighLightedObject?.gameObject)
					{
						HighLightedObject = hit.transform.GetComponent<GrabbableBehaviour>();
						HighLightedObject?.HighLight(true);
					}
				}
				else 
				{					
					HighLightedObject?.HighLight(false);
					HighLightedObject = null;
				}
			if(GrabbedObject != null)
				GrabbedObject.transform.position = this.transform.position;
		}

		void LateUpdate()
		{
			Velocity = transform.position - LastPosition;
			LastPosition = transform.position;
		}

		public void OnGrabEvent()
		{		
			if(HighLightedObject == null)
				return;
			HighLightedObject.Grabbed(this.transform);
			GrabbedObject = HighLightedObject;
		}

		public float ThrowForce;

		public void OnLetGoEvent()
		{
			if(GrabbedObject == null)
				return;			
			GrabbedObject.LetGo(Velocity * ThrowForce);			
			GrabbedObject = null;
		}
		
		private void OnDrawGizmos() 
		{
			Gizmos.color = Color.red;
			Gizmos.DrawRay(transform.position, transform.forward * MaxGrabDistance);	
		}	
	}
}
