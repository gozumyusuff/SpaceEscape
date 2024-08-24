using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        MissileCollision.MissileBetweenCrashEvent += AddPoint;
    }

    private void OnDisable()
    {
        MissileCollision.MissileBetweenCrashEvent -= AddPoint;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    public void AddPoint(Vector3 position)
    {
        score += 1;
        scoreText.text = "SCORE: " + score.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
