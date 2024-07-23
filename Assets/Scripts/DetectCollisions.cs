using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        // Destory animals that do not have a health bar
        if (other.CompareTag("Animal (Without Health)"))
        {
            Destroy(other.gameObject);
            ScoreManager.Instance.IncreaseScore();
        }
    }
}
