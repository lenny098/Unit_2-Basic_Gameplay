using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Animal collided with player, Game Over!");
        scoreManager.DecreaseLives();
    }
}
