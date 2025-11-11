// using TMPro;
// using UnityEngine;
// using UnityEngine.SocialPlatforms.Impl;

// public class ScoreManager : MonoBehaviour
// {

//     [SerializeField] TextMeshProUGUI scoreText;

//     int score = 0;

//     public void Addscore(int additionalScore)
//     {
//         score += additionalScore;
//         scoreText.text = "Score: " + score;
//     }

// }

using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    public void Addscore(int additionalScore)
    {
        score += additionalScore;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public int GetCurrentScore()
    {
        return score;
    }
}


