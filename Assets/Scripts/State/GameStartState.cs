using UnityEngine;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class GameStartState : State
    {
		public override void OnEnter()
        {
            GameObject.Instantiate(Resources.Load("MyPrefab"), new Vector3(0, 0, 0), Quaternion.identity);
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
