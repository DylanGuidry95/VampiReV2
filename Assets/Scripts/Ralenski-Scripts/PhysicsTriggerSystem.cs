using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;

namespace Ralenski
{
    [CreateAssetMenu]
    public class PhysicsTriggerSystem : MonoBehaviour
    {
        public GameEvent TriggerEnter;
        public GameEvent TriggerExit;
        public GameEvent TriggerStay;
        void OnTriggerEnter(Collider other)
        {//the other collider's attached rigidbodies game object's name.
            if (other.gameObject.name=="Player")
            {
                TriggerEnter.Raise();
                Debug.Log("Trigger Enter Raised");
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                TriggerExit.Raise();
                Debug.Log("Trigger Exit Raised");
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                TriggerStay.Raise();
                Debug.Log("Trigger Stay Raised");
            }
         }


        // Use this for initialization
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}