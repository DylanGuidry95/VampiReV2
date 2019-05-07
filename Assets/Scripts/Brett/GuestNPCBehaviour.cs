using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Brett
{
    public class GuestNPCBehaviour : MonoBehaviour
    {
        public Transform Target;

        public float AngleOfView;
        public float DistanceOfView;

        private FeedingBehaviour _feedingBehaviour;
        private Animator _anim;

        private RaycastHit _hit;

        public GameEvent OnGameExit;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _feedingBehaviour = gameObject.GetComponent<FeedingBehaviour>();
        }

        private void Update()
        {

            PlayerDetection();

            if (_feedingBehaviour._npcIsDead)
            {
                Debug.Log("NPC is dead.");
                //_anim.SetBool("isDead", true);
                OnGameExit.Raise();
            }
        }

        public bool ICanSeeThePlayer = false;

        void PlayerDetection()
        {
            var targetDir = Target.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
            float distance = Vector3.Distance(Target.position, transform.position);
            //print(distance + ": between target and npc");
            if (angle <= AngleOfView && distance <= DistanceOfView)
            {
                Debug.DrawLine(transform.position, Target.transform.position, Color.blue);
                if (Physics.Linecast(transform.position, Target.transform.position, out _hit))
                {
                    if (_hit.collider.CompareTag("Player"))
                    {
                        //print("NPC can see player");
                        ICanSeeThePlayer = true;
                    }
                    else
                    {
                        ICanSeeThePlayer = false;
                    }
                }
            }
        }
    }
}