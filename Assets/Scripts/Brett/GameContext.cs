using UnityEngine;
using Valve.VR;

namespace Assets.Scripts.Brett
{
    [CreateAssetMenu,System.Serializable]
    public class GameContext : Context
    {
        public string StateName;
        public ConditionScriptable conditions;
 
        public override State CurrentState { get; set; }

        public override void ChangeState(State s)
        {
            CurrentState.OnExit();
            CurrentState = s;
            CurrentState.OnEnter();
        }

        public override void Start()
        {
            CurrentState.OnEnter();
        }

        public override void Update()
        {
            StateName = CurrentState.ToString();
            CurrentState.Update(this, conditions);
        }
    }

    public class SceneFadeUtility
    {
        public static void FadeIn(float time)
        {
            SteamVR_Fade.Start(Color.black, 0f);
            SteamVR_Fade.Start(Color.clear, time);
        }

        public static void FadeOut(float time)
        {
            SteamVR_Fade.Start(Color.clear, 0f);
            SteamVR_Fade.Start(Color.black, time);
        }
    }
}
