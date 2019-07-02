using System.Collections;
using System.Collections.Generic;
using Ralenski;
using UnityEngine;
namespace Ralenski
{
    public class TriggerLerp : MonoBehaviour
    {
        LerpBehaviour lb;
        void OnCollisionEnter(Collision coll)
        {
            if (coll.gameObject.CompareTag("Ground"))
            //if the other rigidbody's gameobject's tag is equal to Throwable is true.
            {
                lb.expand = true;
            }
        }

        // Use this for initialization
        void Start()
        {
            lb = GetComponent<LerpBehaviour>();
        }
    }

}

