using System;
using UnityEngine;
[CreateAssetMenu(menuName = "EventChannel/AudioChannel")]
public class AudioChannelSO : ScriptableObject
{
    private Action<AudioClip> OnAction;
    public void AddListener(Action<AudioClip> action)
    {
        OnAction += action;
    }
    public void RemoveListener(Action<AudioClip> action)
    {
        OnAction += action;
    }
    public void PlayClip(AudioClip clip)
    {
        OnAction?.Invoke(clip);
    }
}
