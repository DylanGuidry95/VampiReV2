using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeckColliderBehaviour : MonoBehaviour
{
    public bool isCollidingWithPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }
}
