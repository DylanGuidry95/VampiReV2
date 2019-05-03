using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class IntroRunningState : State
    {

		public override void OnEnter()
		{
            GameObject.Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0, 0, 0), Quaternion.identity);
            FadeUtility.FadeIn(3);
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

				if(conditionScriptable.conditions[i].name == "OnGameStart" && conditionScriptable.conditions[i].isRaised)
                {
                    timer -= Time.deltaTime;

                    if (isRaised == false)
                    {
                        FadeUtility.FadeOut(3);
                    }
                    isRaised = true;

                    if (timer < 0)
                    {
                        c.ChangeState(new GameStartState());
                        conditionScriptable.Toggle("OnGameStart");

                        SceneManager.LoadScene("0.main");
                    }
                }

			}
		}
	}
}
