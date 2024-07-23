using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;

    public static ScoreManager Instance;

    public void IncreaseScore()
    {
        score += 1;
        Debug.Log($"Score = {score}");
    }

    public void DecreaseLives()
    {
        lives = Mathf.Max(lives - 1, 0);
        Debug.Log($"Lives = {lives}");

        if (lives < 1)
        {
            Debug.Log("Game Over!");
        }
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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Game Start, Lives = {lives} Score = {score}");
    }
}
