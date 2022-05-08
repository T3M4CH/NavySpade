using System;
using UnityEngine;
[CreateAssetMenu(menuName = "EventChannel/VectorChannel")]
public class VectorChannelSO : ScriptableObject
{
    private Action<Vector3> OnClick;
    public void AddListener(Action<Vector3> action)
    {
        OnClick += action;
    }
    public void RemoveListener(Action<Vector3> action)
    {
        OnClick += action;
    }
    public void Invoke(Vector3 vector)
    {
        OnClick?.Invoke(vector);
    }
}
