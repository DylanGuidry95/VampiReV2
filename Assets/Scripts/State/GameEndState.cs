using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using Valve.VR;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class GameEndState : State
	{
		public override void OnEnter()
		{

        }

		public override void OnExit()
		{
        }

		public override void Update(Context c, ConditionScriptable conditionScriptable)
		{
			for (int i = 0; i < conditionScriptable.conditions.Count; i++)

            { 
				if(conditionScriptable.conditions[i].name == "OnIntroStart" && conditionScriptable.conditions[i].isRaised)
				{
					c.ChangeState(new IntroStartState());
					conditionScriptable.Toggle("OnIntroStart");

                    SceneManager.LoadScene("1.Intro");
                }



			}
		}
	}
}
