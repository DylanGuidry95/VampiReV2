using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Dylan;
using UnityEngine;

namespace Assets.Scripts.Brett
{

    public class FeedingBehaviour : MonoBehaviour
    {
        public GameObject Neck;

        public GameObject LeftShoulder;

        public GameObject RightShoulder;

        private NeckColliderBehaviour _neck;
        private FeedingGrabbableBehaviour _leftShoulder;
        private FeedingGrabbableBehaviour _rightShoulder;

        public bool _npcIsDead = false;

        // Use this for initialization
        void Start()
        {
            _neck = Neck.GetComponent<NeckColliderBehaviour>();
            _leftShoulder = LeftShoulder.GetComponent<FeedingGrabbableBehaviour>();
            _rightShoulder = RightShoulder.GetComponent<FeedingGrabbableBehaviour>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_neck.isCollidingWithPlayer && _leftShoulder.isGrabbed && _rightShoulder.isGrabbed)
            {
                _npcIsDead = true;
            }
        }
    }
}
