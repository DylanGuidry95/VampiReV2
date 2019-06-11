using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSoundWave : MonoBehaviour {

    public float lifetime;
    SoundWaveBehaviour swb;
    public void destroySoundwave(GameObject temp, float time)
    {
        temp = swb.prefab;
        time = lifetime;
        Destroy(temp, time);
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
    }
}
