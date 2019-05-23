using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;

namespace Assets.Scripts.Brett
{

    public class EndSceneBehaviour : MonoBehaviour
    {
        public GameEvent OnExit;

        public float LogoTimer;

        private float timer = 6.0f;
        private bool isRaised = false;
        private bool isRaised2 = false;

        public GameObject PlayerPrefab;

        void Start()
        {
            Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            FadeUtility.FadeIn(3);
        }

        void Update()
        {
            LogoTimer -= Time.deltaTime;
            if (LogoTimer < 0 && !isRaised)
            {
                isRaised = true;
                FadeUtility.FadeOut(3);
            }

            if (isRaised)
            {
                timer -= Time.deltaTime;
                if (timer < 0 && !isRaised2)
                {
                    isRaised2 = true;
                    OnExit.Raise();
                }
            }
        }
    }
}