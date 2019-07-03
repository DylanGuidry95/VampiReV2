using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

namespace Assets.Scripts.Brett
{
    [System.Serializable]
    public class GameRunningState : State
    {
        public override void OnEnter()
        {
            //GameObject.Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0, 0, 0), Quaternion.identity);
            FadeUtility.FadeIn(3);
        }

        public override void OnExit()
        {

        }

        private float timer = 3.0f;
        private bool fading = false;

        public override void Update(Context c, ConditionScriptable conditionScriptable)
        {
            for (int i = 0; i < conditionScriptable.conditions.Count; i++)

            {
                if (conditionScriptable.conditions[i].name == "OnGameEnd" &&
                   conditionScriptable.conditions[i].isRaised)
                {
                    timer -= Time.deltaTime;
                    Debug.Log(timer);
                    if (!fading)
                    {
                        FadeUtility.FadeOut(3);
                        fading = true;
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
