using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : MonoBehaviour
{
    public List<GameObject> WP;
    private int currentWP, nextWP;
    public GameObject npc;
    float timer;
    public float delay;
    bool PH = true;

    // Use this for initialization
    void Start()
    {
        currentWP = Random.Range(0, WP.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //for (timer = 0; timer <= delay; timer++)
        //{
        //    print(Time.deltaTime * Time.deltaTime);
        //    if (timer >= delay)
        //    {
        //        MoveToNewPosition();
        //        timer = 0;
        //    }

        //}
        if(PH == true)
        {
            MoveToNewPosition();
        }
    }

    public void MoveToNewPosition()
    {
        nextWP = Random.Range(0, WP.Count);
        if (nextWP != currentWP)
        {
            print("Hit new WP");
            npc.transform.position = WP[nextWP].transform.position;
            currentWP = nextWP;
            PH = false;
            StartCoroutine(Seconds());
        }
    }

    IEnumerator Seconds()
    {
        yield return new WaitForSecondsRealtime(3);
        PH = true;
    }

}
