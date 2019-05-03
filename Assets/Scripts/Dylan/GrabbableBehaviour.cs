using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Dylan
{
public class GrabbableBehaviour : MonoBehaviour
{
		private Material BaseMaterial;
		public Material HighLightMaterial;

		void Awake()
		{
			BaseMaterial = GetComponent<MeshRenderer>().material;
		}

		void Start()
		{
				
		}

		public virtual void Grabbed(GrabBehaviour grabber = null)
		{						
			GetComponent<Rigidbody>().useGravity = false;			
			GetComponent<Rigidbody>().isKinematic = true;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().Sleep();
			GetComponent<Rigidbody>().WakeUp();
		}	

		public virtual void LetGo(Vector3 travelVelocity, GrabBehaviour grabber = null)
		{			
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().velocity += travelVelocity;
		}

		public void HighLight(bool isHighlighted)
		{
			GetComponent<MeshRenderer>().material = (isHighlighted) ? HighLightMaterial : BaseMaterial;
		}				
	}
}
