using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Dylan;
using UnityEngine;

namespace Assets.Scripts.Brett
{
    public class InteractionColliderBehaviour : MonoBehaviour
    {

        public GrabbableBehaviour HighLightedObject;
        public Vector3 HitLocation;

        private void OnTriggerEnter(Collider other)
        {
            HitLocation = other.transform.position;
            HighLightedObject = other.GetComponent<GrabbableBehaviour>();
            HighLightedObject?.HighLight(true);
        }

        private void OnTriggerExit(Collider other)
        {
            HighLightedObject?.HighLight(false);
            HighLightedObject = null;
        }
    }
}