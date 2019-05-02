using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using JetBrains.Annotations;
using UnityEngine;
using Valve.VR;

public class FadeInAndOutBehaviour : MonoBehaviour
{
    //public bool FadeIn = false;
    //public bool FadeOut = false;

    //public Texture2D fadeTexture;

    //float fadeSpeed = 0.2f;

    //int drawDepth = -1000;

    //private float fadeDir = -1f;

    //private float FadeInAlpha = 1.0f;
    //private float FadeOutAlpha = 0.0f;


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
        //if (FadeIn)
        //{

        //    FadeInAlpha += fadeDir * fadeSpeed * Time.deltaTime;
        //    FadeInAlpha = Mathf.Clamp01(FadeInAlpha);

        //    GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, FadeInAlpha);

        //    GUI.depth = drawDepth;

        //    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        //}

        //if (FadeOut)
        //{
        //    FadeOutAlpha -= fadeDir * fadeSpeed * Time.deltaTime;
        //    FadeOutAlpha = Mathf.Clamp01(FadeOutAlpha);

        //    GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, FadeOutAlpha);

        //    GUI.depth = drawDepth;

        //    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        //    SteamVR_Fade.Star
        //}
    }

    //public void TurnOnFadeIn()
    //{
    //    FadeIn = true;
    //}

    //public void TurnOnFadeOut()
    //{
    //    FadeOut = true;
    //}
}
