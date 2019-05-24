using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Brett
{

    public class FeedingGrabbableBehaviour : GrabbableBehaviour
    {
        public bool isGrabbed;


        public override void Grabbed(GrabBehaviour grabber = null)
        {
            isGrabbed = true;
        }

        public override void LetGo(Vector3 travelVelocity, GrabBehaviour grabber = null)
        {
            isGrabbed = false;
        }
    }
}