using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveBehaviour : MonoBehaviour {

    public GameObject prefab;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Ground"))
        {
            Instantiate(prefab, transform.position, Quaternion.Euler(90, 0, 0));
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
