using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Dylan{


[RequireComponent(typeof(InteractionRaycastBehaviour))]
	public class GrabBehaviour : MonoBehaviour 
	{
		public GrabbableBehaviour GrabbedObject;
		protected InteractionRaycastBehaviour RayCastBehaviourRef;

		Vector3 GrabberVelocity;
		Vector3 LastFramePosition;

		public Vector3 GrabbedLocation;

		public enum HandRole
		{
			right, left
		}

		public HandRole Role = HandRole.right;

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			RayCastBehaviourRef = GetComponent<InteractionRaycastBehaviour>();	
		}

		private void Update() 
		{
			if(GrabbedObject == null)
				return;			
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

		public virtual void GrabObject()
		{
			if(RayCastBehaviourRef.HighLightedObject == null)
				return;
			GrabbedObject = RayCastBehaviourRef.HighLightedObject;
			GrabbedLocation = RayCastBehaviourRef.HitLocation;
			GrabbedObject.Grabbed(this);
		}

		public virtual void LetGoObject()
		{
			if(GrabbedObject == null)
				return;
			GrabbedObject.LetGo(GrabberVelocity * maxVelocity);			
			GrabbedObject = null;
		}
	}
}