using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using JetBrains.Annotations;
using UnityEngine;
using Valve.VR;

public class FadeInAndOutBehaviour : MonoBehaviour
{



    void Start ()
    {
        FadeIn();
	}
	
	void Update ()
    {

	}

    public void FadeIn()
    {
        SteamVR_Fade.Start(Color.black, 0f);
        SteamVR_Fade.Start(Color.clear, 3f);
    }

    public void FadeOut()
    {
        SteamVR_Fade.Start(Color.clear, 0f);
        SteamVR_Fade.Start(Color.black, 3f);
    }

    private void OnGUI()
    {

}
