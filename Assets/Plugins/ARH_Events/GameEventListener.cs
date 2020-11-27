using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

[HideMonoScript]
public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    [PropertyOrder(2)]
    public UnityEvent Response;

    private void OnEnable() =>
        Event?.RegisterListener(this);

    private void OnDisable() =>
        Event?.UnregisterListener(this);

    [Button("Raise")]
    [PropertyOrder(1)]
    public void OnEventRaised() =>
        Response?.Invoke();
}
