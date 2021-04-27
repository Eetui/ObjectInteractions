using System.Collections.Generic;
using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        namespace Events
        {
            [CreateAssetMenu(menuName = "Eetu/Game Event", fileName = "Game Event")]
            public class GameEvent : ScriptableObject
            {
                List<GameEventListener> listeners = new List<GameEventListener>();

                public void Invoke()
                {
                    foreach (var listener in listeners)
                    {
                        listener.TriggerEvent();
                        Debug.Log($"{name} Event has been invoked", this);
                    }
                }

                public void AddListener(GameEventListener gameEventListener) => listeners.Add(gameEventListener);

                public void RemoveListener(GameEventListener gameEventListener) => listeners.Remove(gameEventListener);
            }
        }
    }
}
