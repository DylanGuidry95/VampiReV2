using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class GameRunningState : State
	{
		public override void OnEnter()
		{
            Resources.Load<GameEvent>("Game Events/OnFadeIn").Raise();
            GameObject.Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0, 0, 0), Quaternion.identity);
        }

		public override void OnExit()
		{
		}

        private float timer = 3.0f;
        private bool isRaised = false;

        public override void Update(Context c, ConditionScriptable conditionScriptable)
		{
			for (int i = 0; i < conditionScriptable.conditions.Count; i++)

			{
				if(conditionScriptable.conditions[i].name == "OnGameEnd" && conditionScriptable.conditions[i].isRaised)
                {
                    timer -= Time.deltaTime;

                    if (isRaised == false)
                    {
                        Resources.Load<GameEvent>("Game Events/OnFadeOut").Raise();
                    }

                    if (timer < 0)
                    {
                        c.ChangeState(new GameEndState());
                        conditionScriptable.Toggle("OnGameEnd");

                        SceneManager.LoadScene("2.End");
                    }
				}

			}
		}
	}
}
