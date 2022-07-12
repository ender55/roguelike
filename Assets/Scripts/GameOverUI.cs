using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Player player;

    private bool isEndOfGame = false;
    
    private void Awake()
    {
        gameObject.SetActive(false);
        player.OnDeath += EnableUI;
    }

    private void OnEnable()
    {
        isEndOfGame = true;
        player.OnDeath -= EnableUI;
    }

    private void Update()
    {
        if (isEndOfGame)
        {
            Restart();
        }
    }

    private void EnableUI()
    {
        gameObject.SetActive(true);
    }

    private void Restart()
    {
        if (Input.GetKeyDown(player.PlayerInput.restartGame))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
