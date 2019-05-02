using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;

public class EndSceneBehaviour : MonoBehaviour
{

    public GameEvent OnFadeIn;
    public GameEvent OnFadeOut;
    public GameEvent OnIntroStart;

    public float LogoTimer;

    private float timer = 3.0f;
    private bool isRaised = false;

    public GameObject PlayerPrefab;

    void Start ()
    {
        Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        OnFadeIn.Raise();
    }
	
	void Update ()
    {
        LogoTimer -= Time.deltaTime;
        if (LogoTimer < 0 && !isRaised)
        {
            isRaised = true;
            OnFadeOut.Raise();            
        }

        if (isRaised)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                OnIntroStart.Raise();
            }
        }
	}
}
