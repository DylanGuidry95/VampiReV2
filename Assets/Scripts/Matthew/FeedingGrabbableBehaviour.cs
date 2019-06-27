using UnityEngine;
using Valve.VR;


namespace Matthew
{
    public class FeedingGrabbableBehaviour : MonoBehaviour
    {
        public bool IsGrabbed;
        public bool IsBeingHovered;
        public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspecter
        public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller


        private void Start()
        {
            //grabPinch.AddOnChangeListener(VRController_OnInteract_ButtonPressed, inputSource);
            grabPinch.AddOnStateDownListener(OnControllerTriggerPress, inputSource);
            grabPinch.AddOnStateUpListener(OnControllerTriggerRelease, inputSource);

        }

        private void OnControllerTriggerPress(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources)
        {
            OnGrabPinchResponse.Invoke();
        }

        private void OnControllerTriggerRelease(SteamVR_Action_Boolean action, SteamVR_Input_Sources sources)
        {
            OnReleasePinchResponse.Invoke();
        }

        [SerializeField]
        private UnityEngine.Events.UnityEvent OnGrabPinchResponse;

        [SerializeField]
        private UnityEngine.Events.UnityEvent OnReleasePinchResponse;

        public void GrabShoulder()
        {
            if(IsBeingHovered)
            {
                IsGrabbed = true;
            }
        }

        public void ReleaseShoulder()
        {
            IsGrabbed = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            IsBeingHovered = true;
        }

        private void OnTriggerExit(Collider other)
        {
            IsBeingHovered = false;
        }
    }

}