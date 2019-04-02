using System.Collections;
using System.Collections.Generic;
using Ralenski;
using UnityEngine;

public class TriggerLerp : MonoBehaviour
{
    public GameObject Throwable;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        //if the collision rigidbody's gameobject's tag is equal to Throwable is true.
        {
            Throwable.GetComponent<LerpBehaviour>().isActiveAndEnabled.Equals(true);
            //enable the lerp behaviour script on the throwable object.
            Debug.Log("Collision with throwable detected");
            Debug.Log("Lerping should start now");
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
