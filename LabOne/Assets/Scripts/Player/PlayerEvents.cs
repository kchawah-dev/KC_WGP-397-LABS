using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public static event Action OnPlayerDied;

    public void Die()
    {
        Debug.Log("Player died");
        OnPlayerDied?.Invoke();
    }
}