using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listerners =
        new List<GameEventListener>();

    [Button("Raise Event")]
    public void Raise()
    {
        for (int i = listerners.Count - 1; i >= 0; i--)
            listerners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListener listener)
    { listerners.Add(listener); }

    public void UnregisterListener(GameEventListener listener)
    { listerners.Remove(listener); }
}
