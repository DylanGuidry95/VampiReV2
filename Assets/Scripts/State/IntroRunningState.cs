using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class IntroRunningState : State
    {

		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
            SceneManager.LoadScene("0.main");
		}

		public override void Update(Context c, ConditionScriptable conditionScriptable)
		{
			for (int i = 0; i < conditionScriptable.conditions.Count; i++)

			{
				if(conditionScriptable.conditions[i].name == "OnExit" && conditionScriptable.conditions[i].isRaised)
				{
					c.ChangeState(new ExitState());
					conditionScriptable.Toggle("OnExit");
				}

				if(conditionScriptable.conditions[i].name == "OnGameStart" && conditionScriptable.conditions[i].isRaised)
				{
					c.ChangeState(new GameStartState());
					conditionScriptable.Toggle("OnGameStart");
				}

			}
		}
	}
}
