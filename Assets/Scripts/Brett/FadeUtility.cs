using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Valve.VR;

namespace Assets.Scripts.Brett
{

    public class FadeUtility
    {
        public static void FadeIn(float time)
        {
            SteamVR_Fade.Start(Color.black, 0f);
            SteamVR_Fade.Start(Color.clear, time);
        }

        public static void FadeOut(float time)
        {
            SteamVR_Fade.Start(Color.clear, 0f);
            SteamVR_Fade.Start(Color.black, time);
        }

        public static void BloodFadeIn(float time)
        {
            SteamVR_Fade.Start(Color.clear, 0f);
            SteamVR_Fade.Start(Color.red, time);
        }

        public static void BloodFadeOut(float time)
        {
            SteamVR_Fade.Start(Color.red, 0f);
            SteamVR_Fade.Start(Color.clear, time);
        }
    }
}