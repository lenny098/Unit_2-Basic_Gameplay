using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // private float zBoundPositive = 30;
    // private float zBoundNegative = -10;

    private Bounds bounds = new Bounds(
        new Vector3(0, 0, 10),
        new Vector3(50, 5, 30)
    );

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bounds.Contains(transform.position))
        {
            Destroy(gameObject);

            // Check whether this game object is projectile
            if (transform.position.z < bounds.max.z)
            {
                // Debug.Log("Game Over!");
                scoreManager.DecreaseLives();
            }
        }
    }
}
