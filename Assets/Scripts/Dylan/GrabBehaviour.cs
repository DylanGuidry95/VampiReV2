using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Dylan{


[RequireComponent(typeof(InteractionRaycastBehaviour))]
	public class GrabBehaviour : MonoBehaviour 
	{
		public GrabbableBehaviour GrabbedObject;
		private InteractionRaycastBehaviour RayCastBehaviourRef;

		Vector3 GrabberVelocity;
		Vector3 LastFramePosition;		

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			RayCastBehaviourRef = GetComponent<InteractionRaycastBehaviour>();	
		}

		private void Update() 
		{
			if(GrabbedObject != null)
			{
				GrabbedObject.transform.position = this.transform.position;
			}
		}

		/// <summary>
		/// LateUpdate is called every frame, if the Behaviour is enabled.
		/// It is called after all Update functions have been called.
		/// </summary>
		public float maxVelocity;
		void LateUpdate()
		{			
			GrabberVelocity = transform.position - LastFramePosition;
			LastFramePosition = transform.position;	
		}

		public void GrabObject()
		{
			if(RayCastBehaviourRef.HighLightedObject == null)
				return;
			GrabbedObject = RayCastBehaviourRef.HighLightedObject;
			GrabbedObject.Grabbed(this.transform);
		}

		public void LetGoObject()
		{
			if(GrabbedObject == null)
				return;			
			GrabbedObject.LetGo(GrabberVelocity * maxVelocity);
			GrabbedObject = null;
		}
	}
}