
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem finishParticles;
    [SerializeField] GameOverUI gameOverUI;  // NEW: Reference to Game Over UI

    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            // Disable player controls
            if (playerController != null)
            {
                playerController.DisableControls();
            }

            // Play finish particles if assigned
            if (finishParticles != null)
            {
                finishParticles.Play();
            }

            // Show game over screen after delay
            Invoke("ShowGameOver", restartDelay);
        }
    }

    void ShowGameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
    }
}


