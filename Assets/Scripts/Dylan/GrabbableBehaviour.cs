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

		public virtual void Grabbed(Transform grabber)
		{			
			transform.position = grabber.transform.position;			
			GetComponent<Rigidbody>().useGravity = false;			
		}
		
		private void Update() 
		{

		}

		public virtual void LetGo(Vector3 travelVelocity)
		{			
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().velocity += travelVelocity;
		}

		public void HighLight(bool isHighlighted)
		{
			GetComponent<MeshRenderer>().material = (isHighlighted) ? HighLightMaterial : BaseMaterial;
		}				
	}
}
