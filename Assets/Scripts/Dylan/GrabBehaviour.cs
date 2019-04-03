using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Dylan{


[RequireComponent(typeof(InteractionRaycastBehaviour))]
	public class GrabBehaviour : MonoBehaviour 
	{
		public GrabbableBehaviour GrabbedObject;
		private InteractionRaycastBehaviour RayCastBehaviourRef;

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
			GrabbedObject.LetGo(Vector3.zero);
			GrabbedObject = null;
		}
	}
}