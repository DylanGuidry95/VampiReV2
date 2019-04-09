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
        Quaternion rotateValue;

        private NewWayPoint NWP;

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
            if (nextWP == currentWP)
            {
                nextWP = Random.Range(0, WP.Count);
            }

            if (PH == true)
            {
                MoveToNewPosition();
            }

            if (npc.transform.position == WP[currentWP].transform.position)
            {
                RotateToNewPosition();

            }

            if (npc.transform.position.x < 1 || npc.transform.position.x > -1)
            {
                RotateToNewPosition();
            }

            if (Input.GetMouseButtonDown(0))
            {
                MoveToItemPosition();
            }
        }

        public void MoveToItemPosition()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                StopCoroutine(Seconds());
            }
        }

        public void MoveToNewPosition()
        {
            if (nextWP != currentWP && WP.Count != 0)
            {
                print("Hit new WP");
                PH = false;
                agent.SetDestination(WP[nextWP].transform.position);
                StartCoroutine(Seconds());
                currentWP = nextWP;
            }
        }

        public void RotateToNewPosition()
        {
            rotateValue = Quaternion.FromToRotation(npc.transform.position, WP[nextWP].transform.position);
            //npc.transform.rotation = rotateValue;
            npc.transform.rotation = Quaternion.AngleAxis(rotateValue.x, Vector3.right);
            //npc.transform.rotation = new Quaternion(0, rotateValue.y, 0, 0);
            StartCoroutine(Rotate());
        }

        IEnumerator Seconds()
        {
            yield return new WaitForSecondsRealtime(6);
            PH = true;
        }

        IEnumerator Rotate()
        {
            yield return new WaitForSecondsRealtime(4);
        }
    }
}


