using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Matt
{
    public class ClosestPointCollider : MonoBehaviour
    {
        public static Vector3 closestpoint;
        public GameObject guard;
        void Start()
        {
            
        }

        void Update()
        {
            
        }
        void OnCollisionEnter(Collision coll)
        {
            if (coll.gameObject.CompareTag("HideAble"))
            {
                var closestgameobj = coll.gameObject;
                Debug.Log("Something hit" + closestgameobj);
                closestpoint = closestgameobj.transform.position;
            }
        }

        public bool WhosCloser(GameObject player)
        {
            bool IsItTho = false;
            var closercollider = Vector3.Distance(closestpoint, guard.transform.position);
            var closerplayer = Vector3.Distance(player.transform.position, guard.transform.position);
            if (closerplayer > closercollider)
            {
                Debug.Log("Collider is closer");
                IsItTho = true;
            }
            else
            {
                Debug.Log("Player is closer");
                IsItTho = false;
            }

            return IsItTho;
        }
    }
}


