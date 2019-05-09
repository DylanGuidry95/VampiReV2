using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Dylan;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Assets.Scripts.Brett
{

    public class FeedingBehaviour : MonoBehaviour
    {
        public GameObject Neck;
        public GameObject LeftShoulder;
        public GameObject RightShoulder;
        public GameObject bone;

        private NeckColliderBehaviour _neck;
        private FeedingGrabbableBehaviour _leftShoulder;
        private FeedingGrabbableBehaviour _rightShoulder;

        public bool _npcIsDead = false;
        public GameObjectVariable left, right;

        void Start()
        {
            _neck = Neck.GetComponent<NeckColliderBehaviour>();
            _leftShoulder = LeftShoulder.GetComponent<FeedingGrabbableBehaviour>();
            _rightShoulder = RightShoulder.GetComponent<FeedingGrabbableBehaviour>();
            
    
        }

        private Vector3 currentAvgPos;

        void Update()
        {
            if (_neck.isCollidingWithPlayer && _leftShoulder.isGrabbed && _rightShoulder.isGrabbed)
            {
                _npcIsDead = true;
            }

            var step = 1 * Time.deltaTime;
            if (_leftShoulder.isGrabbed && _rightShoulder.isGrabbed)
            {
                var averagePos = (left.Value.transform.position + right.Value.transform.position) / 2;
                Vector3 rotate = currentAvgPos - averagePos;
                currentAvgPos = averagePos;
                bone.transform.Rotate(new Vector3(0, 0, 1), -rotate.z * 20);
            }
        }
    }
}

//===========Try============
// get the average position of both hands
// when shoulders are grabbed.
// rotate the bone towards the average positon of the hands.
// use vector3.RotateTowards.
// then assign bone.Transform.rotation the returned direction