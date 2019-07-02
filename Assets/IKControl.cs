using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator;
    
    public bool ikActive = false;
    [Tooltip("This is what they look at")]
    public Transform lookObj = null;
    
    
    float lookatdistance = 2;
    void Start()
    {
        animator = GetComponent<Animator>();
    
    }
    
    
    public float lookatweight = 1;
    //a callback for calculating IK
    void OnAnimatorIK()
    {
    
        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {

                var lookdir = (lookObj.position - transform.position).normalized;
                lookatweight = Vector3.Dot(transform.forward, lookdir);

                // Set the look target position, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(lookatweight);
                    animator.SetLookAtPosition(lookObj.position);
                }


            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
 
                animator.SetLookAtWeight(0);
            }
        }
    }
}