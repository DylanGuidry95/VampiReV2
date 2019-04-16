using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class GameStartState : State
    {
		public override void OnEnter()
        {
            var gameEvent = Resources.Load<GameEvent>("Game Events/OnGameRun");
            gameEvent.Raise();
        }

		public override void OnExit()
		{
		}

		public override void Update(Context c, ConditionScriptable conditionScriptable)
		{
			for (int i = 0; i < conditionScriptable.conditions.Count; i++)

			{
				if(conditionScriptable.conditions[i].name == "OnGameRun" && conditionScriptable.conditions[i].isRaised)
				{
					c.ChangeState(new GameRunningState());
					conditionScriptable.Toggle("OnGameRun");
				}

			}
		}
	}
}
