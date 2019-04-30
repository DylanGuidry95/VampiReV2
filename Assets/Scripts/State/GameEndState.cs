using UnityEngine;
using UnityEngine.SceneManagement;

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

        private float timer = 3.0f;
        private bool isRaised = false;

        public override void Update(Context c, ConditionScriptable conditionScriptable)
		{
			for (int i = 0; i < conditionScriptable.conditions.Count; i++)

			{
				if(conditionScriptable.conditions[i].name == "OnExit" && conditionScriptable.conditions[i].isRaised)
				{
					c.ChangeState(new ExitState());
					conditionScriptable.Toggle("OnExit");
				}

				if(conditionScriptable.conditions[i].name == "OnIntroStart" && conditionScriptable.conditions[i].isRaised)
				{
                    timer -= Time.deltaTime;

                    if (isRaised == false)
                    {
                        Resources.Load<GameEvent>("Game Events/OnFadeOut").Raise();
                    }
                    isRaised = true;
                    c.ChangeState(new IntroStartState());
					conditionScriptable.Toggle("OnIntroStart");



                    SceneManager.LoadScene("1.Intro");
                }

			}
		}
	}
}
