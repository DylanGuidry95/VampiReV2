using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;

public class GameStartBehaviour : MonoBehaviour
{
    public GameEvent OnFadeOut;
    public GameEvent OnGameStart;
    private bool BeginCountdown;
    private float timer = 3.0f;

    private void Update()
    {
        if (BeginCountdown)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                OnGameStart.Raise();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnFadeOut.Raise();

    }
}
