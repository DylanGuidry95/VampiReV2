using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Dylan
{
	[RequireComponent(typeof(LineRenderer))]
	public class InteractionRaycastBehaviour : MonoBehaviour 
	{		
		public float MaxGrabDistance;
		public GrabbableBehaviour HighLightedObject;

		private LineRenderer LineRendererRef;
		bool IsDrawingLine;

		// Use this for initialization
		void Awake () {
			MaxGrabDistance = Mathf.Clamp(MaxGrabDistance, 0.01f, Mathf.Infinity);
			LineRendererRef = GetComponent<LineRenderer>();			
		}

		void Start()
		{
			LineRendererRef.SetPosition(1, transform.position);
		}		

		private void Update() 
		{
			RaycastHit hit;			
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

			LineRendererRef.enabled = IsDrawingLine;				
			LineRendererRef.SetPosition(0, transform.position);
			LineRendererRef.SetPosition(1, (IsDrawingLine) ? transform.position + (transform.forward * MaxGrabDistance) : transform.position);
		}
		
		public void ToggleLine()
		{
			IsDrawingLine = !IsDrawingLine;
		}

		private void OnDrawGizmos() 
		{
			Gizmos.color = Color.red;
			Gizmos.DrawRay(transform.position, transform.forward * MaxGrabDistance);	
		}	
	}
}
