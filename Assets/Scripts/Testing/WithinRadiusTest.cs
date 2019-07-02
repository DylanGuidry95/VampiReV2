using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Matt
{
    public class WithinRadiusTest : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            
        }

        public void UpdateGuardPosition(Vector3 targetTran)
        {
            transform.LookAt(targetTran);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}

