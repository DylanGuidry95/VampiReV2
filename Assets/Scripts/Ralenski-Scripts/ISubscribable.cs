using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Brett;
using UnityEngine;

namespace Ralenski
{
    public interface ISubscribable
    {
        void Subscribe(GameEventListener listener, GameEvent gEvent);

    }

    public class SubcriberBehaviour : MonoBehaviour
    {
        public List<GameEvent> RaiseableEvents = new List<GameEvent>();
        public string subcriberName;
        void RaiseEvent (GameEvent gEvent)
        {
            RaiseableEvents.Add(gEvent);
          
            
        }

    }
}

