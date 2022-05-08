using System;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStats")]
public class PlayerInfoSO : ScriptableObject
{
    public int Health => _health;
    [SerializeField] private int _health;
    public int MoveSpeed => _moveSpeed;
    [SerializeField] private int _moveSpeed;
    private Action OnPlayerDie;
    public void AddListener(Action action)
    {
        OnPlayerDie += action;
    }
    public void RemoveListener(Action action)
    {
        OnPlayerDie -= action;
    }
    public void InvokeDie()
    {
        OnPlayerDie?.Invoke();
    }
}