using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimationController : MonoBehaviour 
{
	public Animator AnimatorRef;
	// Update is called once per frame
	public void HandAnimation(int val)
	{
		AnimatorRef.SetInteger("AnimationState", val);
	}
}
