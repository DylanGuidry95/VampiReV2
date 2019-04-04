using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Matt
{
    public class WanderBehavior : MonoBehaviour
    {
        public List<GameObject> WP;
        private int currentWP, nextWP;
        public GameObject npc;
        bool PH = true;
        NavMeshAgent agent;
        public Vector3 newDir;

        NewWayPoint NWP;

        // Use this for initialization
        void Start()
        {
            currentWP = Random.Range(0, WP.Count);
            nextWP = Random.Range(0, WP.Count);
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(nextWP == currentWP)
            {
                nextWP = Random.Range(0, WP.Count);
                
            }
            //npc.transform.rotation = Quaternion.RotateTowards(WP[currentWP].transform.rotation, WP[nextWP].transform.rotation, 360);
            if (PH == true)
            {
                MoveToNewPosition();
            }
            if(!agent.isStopped)
            {
                var targetPosition = WP[nextWP].transform.position;
                var targetPoint = WP[nextWP].transform.position;
                var _direction = (targetPoint - targetPosition).normalized;
                var _lookRotation = Quaternion.LookRotation(_direction);

                npc.transform.rotation = Quaternion.RotateTowards(WP[currentWP].transform.rotation, WP[nextWP].transform.rotation, 360);
            }
        }

        public void MoveToNewPosition()
        {
            
            if (nextWP != currentWP && WP.Count != 0)
            {
                Vector3 targetDir = WP[nextWP].transform.position - npc.transform.position;
                print("Hit new WP");
                PH = false;
                agent.SetDestination(WP[nextWP].transform.position);
                float step = 2.0f * Time.deltaTime;
                newDir = Vector3.RotateTowards(npc.transform.position, WP[nextWP].transform.position, step, 0.0f);
                StartCoroutine(Seconds());
                currentWP = nextWP;
            }
        }

        IEnumerator Seconds()
        {
            yield return new WaitForSecondsRealtime(6);
            PH = true;
        }
    }
}


