using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Assets.Scripts.Brett
{
    public class FeedingGrabbableBehaviour : Throwable
    {
        public bool isGrabbed;


        protected override void OnAttachedToHand(Hand hand)
        {
            isGrabbed = true;
            Debug.Log("Is  currently grabbed");
        }

        protected override void OnDetachedFromHand(Hand hand)
        {
            isGrabbed = false;
            Debug.Log("Is let go");
        }

        protected override void HandAttachedUpdate(Hand hand)
        {
            
        }

        protected override void OnHandFocusAcquired(Hand hand)
        {
            gameObject.SetActive(true);
        }

        protected override void OnHandFocusLost(Hand hand)
        {
            gameObject.SetActive(false);
        }
    }
}