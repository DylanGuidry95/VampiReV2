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
            Debug.Log("Is Grabbed");
        }

        protected override void OnDetachedFromHand(Hand hand)
        {
            isGrabbed = false;
            Debug.Log("Is Let Go");
        }
    }
}