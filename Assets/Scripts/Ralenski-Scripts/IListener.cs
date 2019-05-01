using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;
namespace Ralenski
{
    public interface IListener 
    {
        
        void DoEvent(GameEvent action);

    }

    public class ListenerBehaviour : MonoBehaviour
    {
        public List<GameEventListener> Listeners= new List<GameEventListener>();
        public GameEvent gameEvent;
     

     
        

    }

}

