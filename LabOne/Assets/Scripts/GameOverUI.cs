using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    void OnEnable()
    {
        PlayerEvents.OnPlayerDied += ShowGameOver;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerDied -= ShowGameOver;
    }

    void ShowGameOver()
    {
        Debug.Log("Game Over UI Triggered");
        gameObject.SetActive(true);
    }
}