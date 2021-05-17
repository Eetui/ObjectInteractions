using UnityEditor;
using UnityEngine;
using AGP.EetuI.Events;

namespace AGP
{
    namespace EetuI
    {
        [CustomEditor(typeof(GameEvent))]
        public class GameEventEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                GUI.enabled = Application.isPlaying;

                GameEvent gameEvent = target as GameEvent;
                if (GUILayout.Button("Invoke Game Event"))
                    gameEvent.Invoke();
            }
        }
    }
}
