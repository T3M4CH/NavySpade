using System;
using UnityEngine;
[CreateAssetMenu(menuName = "EventChannel/IntChannel")]
public class IntChannelSO : ScriptableObject
{
    private Action<int> OnAction;
    public void AddListener(Action<int> action)
    {
        OnAction += action;
    }
    public void RemoveListener(Action<int> action)
    {
        OnAction += action;
    }
    public void Invoke(int count)
    {
        OnAction?.Invoke(count);
    }
}