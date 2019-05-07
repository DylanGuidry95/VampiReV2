using UnityEngine;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class ExitState : State
	{
		public override void OnEnter()
		{
			Debug.Log("Hit");
            Application.Quit();
		}

		public override void OnExit()
		{
		}

		public override void Update(Context c, ConditionScriptable conditionScriptable)
		{
			for (int i = 0; i < conditionScriptable.conditions.Count; i++)

			{
			}
		}
	}
}
