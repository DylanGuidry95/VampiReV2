using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Dylan;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;
using Matthew;
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
        public GameObject ragdollHanger;

        private NeckColliderBehaviour _neck;
        private FeedingGrabbableBehaviour _leftShoulder;
        private FeedingGrabbableBehaviour _rightShoulder;

        public bool _npcIsDead = false;
        public bool RagdollIsActive = false;
        public GameObjectVariable left, right;

        public GameEvent OnGameEnd;
        public GameEvent OnNPCDead;
        public GameEvent OnActivateRagdoll;

        public Vector3 avgHandPos;
        public Vector3 startingPos;


        void Start()
        {
            _neck = Neck.GetComponent<NeckColliderBehaviour>();
            _leftShoulder = LeftShoulder.GetComponent<FeedingGrabbableBehaviour>();
            _rightShoulder = RightShoulder.GetComponent<FeedingGrabbableBehaviour>();
        }

        private Vector3 currentAvgPos;
        private float timer = 5;
        private float bloodFadeTimer = 1;
        private bool alreadyFadedOut = false;
        private bool alreadyFadedIn = false;



        void Update()
        {
            if (_neck.isCollidingWithPlayer)
            {
                if (!alreadyFadedIn)
                {
                    FadeUtility.BloodFadeIn(1);
                }
                alreadyFadedIn = true;
                _npcIsDead = true;
                OnNPCDead.Raise();
            }

            if (_leftShoulder.IsGrabbed && _rightShoulder.IsGrabbed)
            {
                OnActivateRagdoll.Raise();
                RagdollIsActive = true;
            }

            if (RagdollIsActive)
            {
                avgHandPos = (left.Value.transform.position + right.Value.transform.position) / 2;
                ragdollHanger.transform.position = avgHandPos;
            }

            if (_npcIsDead)
            {
                bloodFadeTimer -= Time.deltaTime;
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    OnGameEnd.Raise();
                }

                if (bloodFadeTimer < 0)
                {
                    if (!alreadyFadedOut)
                    {
                        FadeUtility.BloodFadeOut(1);
                    }
                    alreadyFadedOut = true;
                }
            }
        }
    }
}
