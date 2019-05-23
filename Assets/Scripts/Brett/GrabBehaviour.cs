using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Brett
{

    [RequireComponent(typeof(InteractionColliderBehaviour))]
    public class GrabBehaviour : MonoBehaviour
    {
        public GrabbableBehaviour GrabbedObject;
        protected InteractionColliderBehaviour ColliderBehaviourRef;

        Vector3 GrabberVelocity;
        Vector3 LastFramePosition;

        public Vector3 GrabbedLocation;

        public enum HandRole
        {
            right, left
        }

        public HandRole Role = HandRole.right;

        private void Awake()
        {
            ColliderBehaviourRef = GetComponent<InteractionColliderBehaviour>();
        }


        private void Update()
        {
            if (GrabbedObject == null)
            {
                return;
            }
        }

        public float maxVelocity;

        private void LateUpdate()
        {
            GrabberVelocity = transform.position - LastFramePosition;
            LastFramePosition = transform.position;
        }

        public virtual void GrabObject()
        {
            if (ColliderBehaviourRef.HighLightedObject == null)
                return;
            GrabbedObject = ColliderBehaviourRef.HighLightedObject;
            GrabbedLocation = ColliderBehaviourRef.HitLocation;
            GrabbedObject.Grabbed(this);
        }

        public virtual void LetGoObject()
        {
            if (GrabbedObject == null)
                return;
            GrabbedObject.LetGo(GrabberVelocity * maxVelocity, this);
            GrabbedObject = null;
        }
    }
}
