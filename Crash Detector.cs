// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class CrashDetector : MonoBehaviour
// {
//     [SerializeField] float restartDelay = 1f;
//     [SerializeField] ParticleSystem crashParticles;
//     PlayerController playerController;

//     void Start()
//     {
//         playerController = FindFirstObjectByType<PlayerController>();
//     }
//     void OnTriggerEnter2D(Collider2D collision)
//     {
//         int layerIndex = LayerMask.NameToLayer("Floor");

//         if (collision.gameObject.layer == layerIndex)
//         {
//             playerController.DisableControls();
//             crashParticles.Play();
//             Invoke("ReloadScene", restartDelay);
//         }
//     }

//     void ReloadScene()
//     {
//         SceneManager.LoadScene(0);
//     }


// }

using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] GameOverUI gameOverUI;  // NEW: Reference to Game Over UI

    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            playerController.DisableControls();
            crashParticles.Play();
            Invoke("ShowGameOver", restartDelay);  // CHANGED: Show game over instead of reload
        }
    }

    void ShowGameOver()  // NEW: Show the game over popup
    {
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
    }
}

