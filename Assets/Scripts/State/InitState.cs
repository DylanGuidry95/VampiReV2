using UnityEngine;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class InitState : State
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
				if(conditionScriptable.conditions[i].name == "OnGameStart" && conditionScriptable.conditions[i].isRaised)
				{
					c.ChangeState(new GameStartState());
					conditionScriptable.Toggle("OnGameStart");
				}

			}
		}
	}
}
