using UnityEngine;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class IntroStartState : State
	{
		public override void OnEnter()
		{
            GameObject.Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0, 0, 0), Quaternion.identity);
            var gameEvent = Resources.Load<GameEvent>("Game Events/OnIntroRun");
            gameEvent.Raise();
        }

		public override void OnExit()
		{
		}

		public override void Update(Context c, ConditionScriptable conditionScriptable)
		{
			for (int i = 0; i < conditionScriptable.conditions.Count; i++)

			{
				if(conditionScriptable.conditions[i].name == "OnIntroRun" && conditionScriptable.conditions[i].isRaised)
				{
					c.ChangeState(new IntroRunningState());
					conditionScriptable.Toggle("OnIntroRun");
				}

			}
		}
	}
}
