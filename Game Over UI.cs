// using TMPro;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class GameOverUI : MonoBehaviour
// {
//     [SerializeField] private GameObject gameOverPanel;
//     [SerializeField] private TextMeshProUGUI finalScoreText;
//     [SerializeField] private TextMeshProUGUI highScoreText;
//     [SerializeField] private ScoreManager scoreManager;

//     private bool isGameOver = false;

//     void Start()
//     {
//         if (gameOverPanel != null)
//             gameOverPanel.SetActive(false);
//     }

//     public void ShowGameOver()
//     {
//         if (isGameOver) return;
//         isGameOver = true;

//         Time.timeScale = 0; // pause the game

//         int finalScore = scoreManager != null ? scoreManager.GetCurrentScore() : 0;
//         int highScore = PlayerPrefs.GetInt("HighScore", 0);

//         if (finalScore > highScore)
//         {
//             highScore = finalScore;
//             PlayerPrefs.SetInt("HighScore", highScore);
//         }

//         finalScoreText.text = "Final Score: " + finalScore;
//         highScoreText.text = "High Score: " + highScore;

//         if (gameOverPanel != null)
//             gameOverPanel.SetActive(true);
//     }

//     public void PlayAgain()
//     {
//         Time.timeScale = 1;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }

//     public void QuitGame()
//     {
//         Application.Quit();
//     }
// }

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI exitConfirmationText;  // NEW
    [SerializeField] private ScoreManager scoreManager;

    private bool isGameOver = false;
    private bool isExitConfirmationShowing = false;  // NEW

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (exitConfirmationText != null)
            exitConfirmationText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check for ESC key press when exit confirmation is showing
        if (isExitConfirmationShowing && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

            // For testing in Unity Editor (since Application.Quit doesn't work in editor)
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    public void ShowGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0; // pause the game

        int finalScore = scoreManager != null ? scoreManager.GetCurrentScore() : 0;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        finalScoreText.text = "Final Score: " + finalScore;
        highScoreText.text = "High Score: " + highScore;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Show the exit confirmation message
        isExitConfirmationShowing = true;

        if (exitConfirmationText != null)
        {
            exitConfirmationText.gameObject.SetActive(true);
            exitConfirmationText.text = "Press ESC to Exit";
        }
    }
}
