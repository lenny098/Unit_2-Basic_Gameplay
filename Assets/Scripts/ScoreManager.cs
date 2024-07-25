using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] Text scoreText;

    [SerializeField] int lives = 3;
    int score = 0;

    void UpdateUI()
    {
        scoreText.text = lives < 1 ? "Game Over!" : $"Lives = {lives}\nScore = {score}";
    }

    public void IncreaseScore()
    {
        score++;
        UpdateUI();
    }

    public void DecreaseLives()
    {
        lives = Mathf.Max(lives - 1, 0);
        UpdateUI();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
