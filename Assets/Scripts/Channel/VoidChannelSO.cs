using System;
using UnityEngine;
[CreateAssetMenu(menuName = "EventChannel/VoidChannel")]
public class VoidChannelSO : ScriptableObject
{
    private Action OnAction;
    public void AddListener(Action action)
    {
        OnAction += action;
    }
    public void RemoveListener(Action action)
    {
        OnAction += action;
    }
    public void Invoke()
    {
        OnAction?.Invoke();
    }
}
