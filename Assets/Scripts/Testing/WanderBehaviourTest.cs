﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Assets.Scripts.Matt
{
    public class WanderBehaviourTest : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        [Header("Time until guard moves")]
        public UnityEngine.Events.UnityEvent Responses;
        public Vector3 currentDestination;
        public int seconds = 6;
        public float secondsToWalk = 3.5f;
        WithinRadiusTest wrt;

        protected float dotproduct;
        protected float maxdelta = 10;
        private Vector3 targetdir;
        [Header("Waypoint Info")]
        public List<Transform> WayPoints;
        public int currentWP, nextWP;
        [Range(0, 100)]
        public float remainingdistance;

        [Header("Range of Player from Guard")]
        public GameObject target;
        public float minRange, maxRange;
        public Vector3 targetTran;
        // Use this for initialization
        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            targetdir = transform.forward;
            currentWP = Random.Range(0, WayPoints.Count);
            StartCoroutine("PatrolRoutine");
            //target = GameObject.FindWithTag("Player");
            targetTran = target.transform.position;
        }

        void Update()
        {
            //targetTran = target.transform.position;
            //bool inRange = Vector3.Distance(transform.position, targetTran) < maxRange && Vector3.Distance(transform.position, targetTran) > minRange;
            //var infront = Vector2.Dot(target.transform.forward, transform.forward) < 0;
            //if (inRange && infront)
            //{
            //    transform.LookAt(targetTran);
            //    transform.Translate(Vector3.forward * Time.deltaTime * 4.25f);
            //}
        }

        public bool WAYPOINTSTRAVEL = true;
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
            yield return new WaitForSeconds(secondsToWalk);

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
            if (_navMeshAgent.stoppingDistance <= _navMeshAgent.remainingDistance)
            {
                var randomindex = Random.Range(0, WayPoints.Count);

                if (currentWP == randomindex)
                {
                    randomindex = Random.Range(0, WayPoints.Count);
                }
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
                if (currentWP == randomindex)
                {
                    randomindex = Random.Range(0, WayPoints.Count);
                }
                currentWP = randomindex;
                yield return StartCoroutine("UpdateRotation", WayPoints[randomindex].position);
            }
            yield return null;
        }

        public void GuardFollowRoutine(Vector3 targ)
        {
            transform.LookAt(targ);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}