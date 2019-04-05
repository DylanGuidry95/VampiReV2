using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;
using Valve.VR;

namespace Ralenski
{
    public class PhysicsTriggerSystem : MonoBehaviour
    {
        public GameEvent TriggerEnter;

        public GameEvent TriggerExit;

        public GameEvent TriggerStay;

        void OnTriggerEnter(Collider other)
        {//the other collider's attached rigidbodies game object's name.
            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerEnter.Raise();
            }

            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerEnter.Raise();
            }
            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerEnter.Raise();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerExit.Raise();
            }
            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerExit.Raise();
            }
            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerExit.Raise();
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerStay.Raise();
            }
            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerStay.Raise();
            }
            if (other.GetComponent<Rigidbody>().detectCollisions == true)
            {
                TriggerStay.Raise();
            }
        }
        public struct GuardTriggerSystem
        {
            private PhysicsTriggerSystem PTS;
            private GameEventListener GuardGEL;
            public List<GameEventListener> EventList;

            public void EventsToListenFor(GameEventListener listener)
            {
                listener.Event.Subscribe(GuardGEL);
                EventList[1].OnEventRaised();
            }
        }
        public struct PlayerTriggerSystem
        {
            private PhysicsTriggerSystem PTS;
            private GameEventListener PlayerGEL;
            public List<GameEventListener> EventList;

            public void EventsToListenFor(GameEventListener listener)
            {
                listener.Event.Subscribe(PlayerGEL);
                EventList[1].OnEventRaised();
            }

        }

        public struct InteractableTriggerSystem
        {
            private PhysicsTriggerSystem PTS;
            private LerpBehaviour LERPY;
            private GameEventListener InterGEL;
            public List<GameEventListener> EventList;

            public void EventsToListenFor(GameEventListener listener)
            {
                listener.Event.Subscribe(InterGEL);
                EventList[1].OnEventRaised();
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