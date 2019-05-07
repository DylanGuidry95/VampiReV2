using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Brett
{
    public class ContextBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Context Context;

        
        public GameStateScriptable GAMESTATEREF;



        void Start()
        {
            if (Context.CurrentState == null)
            {
                Context.CurrentState = GAMESTATEREF.StateField;
                Context.Start();
            }
        }

        private void Update()
        {
            Context.Update();
        }
    }
}
