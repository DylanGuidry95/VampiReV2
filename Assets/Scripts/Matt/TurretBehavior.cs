using UnityEngine;
using UnityEngine.AI;

namespace Rain.Behaviour
{
    public class TurretBehavior : MonoBehaviour
    {
        public GameObject player;
        LayerMask layermask = -1;
        RaycastHit hit;
        public ClosestPointCollider[] cpc;
        public GameObject[] hideables;
        NavMeshAgent agent;
        public float AoV;
        public float DoV;

        public GameObject[] lines;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            var targetDir = player.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (angle <= AoV && distance <= DoV)
            {
                for (int i = 0; i < cpc.Length; i++)
                {
                    if (cpc[i].WhosCloser(player) == false)
                    {
                        agent.SetDestination(player.transform.position);
                        Debug.DrawLine(transform.position, player.transform.position, Color.blue);
                    }
                    cpc[i].WhosCloser(player);
                }

            }
            for (int i = 0; i < lines.Length; i++)
            {
                Debug.DrawLine(transform.position, lines[i].transform.position, Color.black);
            }



            if (Physics.Raycast(transform.position, Vector3.forward, out hit, layermask))
            {
                Debug.Log("Hits fine");
            }
        }
    }
}
