using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;

namespace Ralenski
{
    [RequireComponent(typeof(Collider))]
    public class PhysicsTriggerSystem : MonoBehaviour
    {

        public string ListenerTag;
        public GameEvent EnterTrigger;
        public GameEvent ExitTrigger;
        public GameEvent TriggerStay;
        public GameEvent CollisionEnter;
        public GameEvent CollisionExit;
        public GameEvent CollisionStay;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(ListenerTag))
            {
                EnterTrigger.Raise();
                Debug.Log("Raise OnTrigger Enter");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(ListenerTag))
            {
                ExitTrigger.Raise();
                Debug.Log("Raise OnTrigger Exit");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(ListenerTag))
            {
                TriggerStay.Raise();
                Debug.Log("Raise OnTrigger Stay");
            }

        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CollisionEnter.Raise();
                Debug.Log("Raise OnCollision Enter");
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CollisionExit.Raise();
                Debug.Log("Raise OnCollision Exit");
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CollisionStay.Raise();
                Debug.Log("Raise OnCollision Stay");
            }
        }
    }
}