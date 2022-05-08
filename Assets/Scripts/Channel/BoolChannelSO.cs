using System;
using UnityEngine;
[CreateAssetMenu(menuName = "EventChannel/BoolChannel")]
public class BoolChannelSO : ScriptableObject
{
    private Action<bool> OnAction;
    public void AddListener(Action<bool> action)
    {
        OnAction += action;
    }
    public void RemoveListener(Action<bool> action)
    {
        OnAction += action;
    }
    public void Invoke(bool result)
    {
        OnAction?.Invoke(result);
    }
}
