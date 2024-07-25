using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] int lives = 3;
    int score = 0;

    public void IncreaseScore()
    {
        score++;
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
