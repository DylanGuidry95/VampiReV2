using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Dylan
{
	public class MultigrabbleBehaviour : GrabbableBehaviour 
	{
		public GrabBehaviour LeftHand;
		public GrabBehaviour RightHand;

		private Vector3 LeftGrabOffsetFromOrigin;
		private Vector3 RightGrabOffsetFromOrigin;
		public Vector3 Center;
		void Update()
		{
			if(LeftHand == null || RightHand == null)
				return;						
			else
			{	
				var xMidPoint = (LeftHand.transform.position.x + RightHand.transform.position.x) / 2;
				var yMidPoint = (LeftHand.transform.position.y + RightHand.transform.position.y) / 2;
				var zMidPoint = (LeftHand.transform.position.z + RightHand.transform.position.z) / 2;
				Center = new Vector3(xMidPoint, yMidPoint, zMidPoint);
				transform.position = Center;								
			}
		}

		public override void Grabbed(GrabBehaviour grabber = null)
		{
			base.Grabbed(grabber);
			Debug.Log(grabber.Role);
			if(grabber.Role == GrabBehaviour.HandRole.right)
				RightHand = grabber;
			else
				LeftHand = grabber;
			ReParent();
		}

		public override void LetGo(Vector3 travelVelocity, GrabBehaviour grabber = null)
		{						
			if(grabber == LeftHand)
				LeftHand = null;
			if(grabber == RightHand)
				RightHand = null;			
			ReParent();
			if(transform.parent == null && LeftHand == null && RightHand == null)
				base.LetGo(travelVelocity, grabber);
		}

		public virtual void ReParent()
		{
			if(LeftHand != null && RightHand == null)
			{				
				LeftGrabOffsetFromOrigin = transform.position - LeftHand.GrabbedLocation;				
				transform.position = LeftHand.transform.position - LeftGrabOffsetFromOrigin;				
			}
			else if(LeftHand == null && RightHand != null)
			{				
				RightGrabOffsetFromOrigin = transform.position - RightHand.GrabbedLocation;				
				transform.position = RightHand.transform.position - RightGrabOffsetFromOrigin;
			}
			else
			{
				transform.parent = null;
				return;
			}
			transform.parent = (LeftHand != null) ? LeftHand.transform : (RightHand != null) ? RightHand.transform : null;
		}
	}
}