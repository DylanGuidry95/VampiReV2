using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Dylan
{
	public class ObstacleCollisionBehaviour : MonoBehaviour 
	{
		public float bounceBack;

		public Assets.Scripts.Brett.GameEvent OnObstacleCollisionEnter;
		public Assets.Scripts.Brett.GameEvent OnObstacleCollisionExit;

		private void OnTriggerEnter(Collider other)
		{
			if(other.GetComponent<Camera>() != null)
				OnObstacleCollisionEnter.Raise();
		}

		private void OnTriggerExit(Collider other)
		{
			if(other.GetComponent<Camera>() != null)
				OnObstacleCollisionExit.Raise();
		}
	}
}