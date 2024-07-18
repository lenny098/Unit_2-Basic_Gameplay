using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;

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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Game Start, Lives = {lives} Score = {score}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
