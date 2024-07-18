using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
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
        Destroy(gameObject);

        // Destory animals that do not have a health bar
        if (other.CompareTag("Animal (Without Health)"))
        {
            Destroy(other.gameObject);
            scoreManager.IncreaseScore();
        }
    }
}
