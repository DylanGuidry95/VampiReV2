using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Assets.Scripts.Matt
{
    public class WanderBehaviourTest : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        public Vector3 currentDestination;
        public UnityEngine.Events.UnityEvent Responses;
        public int seconds = 1;


        public float dotproduct;
        public float maxdelta = 10;
        private Vector3 targetdir;
        public float timer = 0.0f;
        [Header("Waypoint Info")]
        public List<Transform> WayPoints;
        public int currentWP, nextWP;
        [Range(0, 100)]
        public float remainingdistance;
        // Use this for initialization
        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            targetdir = transform.forward;
            currentWP = Random.Range(0, WayPoints.Count);
            StartCoroutine("PatrolRoutine");
        }

        public bool WAYPOINTSTRAVEL = false;
        IEnumerator PatrolRoutine()
        {
            while (true)
            {
                Responses.Invoke();
                if (WAYPOINTSTRAVEL)
                    yield return StartCoroutine("SearchRoutine");
                yield return null;
            }
        }

        public IEnumerator DrawLines()
        {
            Debug.DrawLine(transform.position, currentDestination, color: Color.blue);
            Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red);
            yield return null;
        }

        public IEnumerator UpdateRotation(object dest)
        {
            _navMeshAgent.destination = transform.position;
            currentDestination = (Vector3)dest;
            targetdir = Vector3.ProjectOnPlane(currentDestination - transform.position, Vector3.up);
            while (Quaternion.Dot(transform.rotation, Quaternion.LookRotation(targetdir)) < 1)
            {
                WAYPOINTSTRAVEL = true;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetdir), maxdelta);
                yield return null;
            }
            yield return new WaitForSeconds(seconds);
            _navMeshAgent.SetDestination(currentDestination);
            yield return new WaitForSeconds(3);

        }
        public void Test()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine("UpdateRotation", hit.point);
            }
        }

        public void NewPosition(int index)
        {
            index = currentWP;
            StartCoroutine("UpdateRotation", WayPoints[index].position);
        }

        public IEnumerator SearchRoutine()
        {
            WAYPOINTSTRAVEL = false;
            remainingdistance = Vector3.Distance(transform.position, currentDestination);
            //if you are close and not already searching then find a new point
            if (_navMeshAgent.stoppingDistance < _navMeshAgent.remainingDistance)
            {
                var randomindex = Random.Range(0, WayPoints.Count);

                if (currentWP == randomindex)
                {
                    randomindex = Random.Range(0, WayPoints.Count);
                }
                currentWP = randomindex;
                yield return StartCoroutine("UpdateRotation", WayPoints[randomindex].position);
            }
            else
            {
                var randomindex = Random.Range(0, WayPoints.Count);

                if (currentWP == randomindex)
                {
                    randomindex = Random.Range(0, WayPoints.Count);
                }
                currentWP = randomindex;

                yield return StartCoroutine("UpdateRotation", WayPoints[randomindex].position);
            }
            yield return null;
        }
    }
}